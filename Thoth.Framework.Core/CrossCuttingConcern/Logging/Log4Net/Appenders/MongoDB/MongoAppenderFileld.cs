using log4net.Layout;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging.Log4Net.Appenders.MongoDB
{
	public class MongoAppenderFileld
	{
		public string Name { get; set; }
		public LayoutSkeleton Layout { get; set; }
	}
}