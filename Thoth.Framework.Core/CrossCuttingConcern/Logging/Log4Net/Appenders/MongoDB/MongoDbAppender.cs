﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Layouts;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Appenders.MongoDB
{
	public class MongoDbAppender : AppenderSkeleton
	{
		private readonly List<MongoAppenderFileld> _fields = new List<MongoAppenderFileld>();

		/// <summary>
		/// MongoDB database connection in the format:
		/// mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
		/// See http://www.mongodb.org/display/DOCS/Connections
		/// If no database specified, default to "log4net"
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		/// The connectionString name to use in the connectionStrings section of your *.config file
		/// If not specified or connectionString name does not exist will use ConnectionString value
		/// </summary>
		public string ConnectionStringName { get; set; }

		/// <summary>
		/// Name of the collection in database
		/// Defaults to "logs"
		/// </summary>
		public string CollectionName { get; set; }

		#region Deprecated

        /// <summary>
        /// Hostname of MongoDB server
		/// Defaults to localhost
        /// </summary>
		[Obsolete("Use ConnectionString")]
		public string Host { get; set; }

        /// <summary>
        /// Port of MongoDB server
		/// Defaults to 27017
        /// </summary>
		[Obsolete("Use ConnectionString")]
		public int Port { get; set; }

        /// <summary>
        /// Name of the database on MongoDB
		/// Defaults to log4net_mongodb
        /// </summary>
		[Obsolete("Use ConnectionString")]
		public string DatabaseName { get; set; }

        /// <summary>
        /// MongoDB database user name
        /// </summary>
		[Obsolete("Use ConnectionString")]
        public string UserName { get; set; }

        /// <summary>
        /// MongoDB database password
        /// </summary>
		[Obsolete("Use ConnectionString")]
		public string Password { get; set; }

		#endregion

		public void AddField(MongoAppenderFileld fileld)
		{
			_fields.Add(fileld);
		}

		protected override void Append(LoggingEvent loggingEvent)
		{
			var collection = GetCollection();
			collection.Insert(BuildBsonDocument(loggingEvent));
		}

		protected override void Append(LoggingEvent[] loggingEvents)
		{
			var collection = GetCollection();
			collection.InsertBatch(loggingEvents.Select(BuildBsonDocument));
		}

	    private MongoCollection GetCollection()
		{
			var db = GetDatabase();
			MongoCollection collection = db.GetCollection(CollectionName ?? "logs");
			return collection;
		}

		private string GetConnectionString()
		{
			ConnectionStringSettings connectionStringSetting = ConfigurationManager.ConnectionStrings[ConnectionStringName];
			return connectionStringSetting != null ? connectionStringSetting.ConnectionString : ConnectionString;
		}

		private MongoDatabase GetDatabase()
		{
			string connStr = GetConnectionString();

			if (string.IsNullOrWhiteSpace(connStr))
			{
				return BackwardCompatibility.GetDatabase(this);
			}

			MongoUrl url = MongoUrl.Create(connStr);

			// TODO Should be replaced with MongoClient, but this will change default for WriteConcern.
			// See http://blog.mongodb.org/post/36666163412/introducing-mongoclient
			// and http://docs.mongodb.org/manual/release-notes/drivers-write-concern
			MongoServer conn = new MongoClient(url).GetServer();/*MongoServer.Create(url);*/

            MongoDatabase db = conn.GetDatabase(url.DatabaseName ?? "log4net");
			return db;
		}

		private BsonDocument BuildBsonDocument(LoggingEvent loggingEvent)
		{
			if(_fields.Count == 0)
			{
				return BackwardCompatibility.BuildBsonDocument(loggingEvent);
			}
			var doc = new BsonDocument();

			foreach(MongoAppenderFileld field in _fields)
			{
				object value = field.Layout.Format(loggingEvent);

                var bsonValue = value as BsonValue ?? BsonValue.Create(value);

                if (field.Layout is JsonLayout)
                {
                    bsonValue = loggingEvent.MessageObject.ToBsonDocument();
                }
			    doc.Add(field.Name, bsonValue);
			}

			return doc;
		}
	}
}