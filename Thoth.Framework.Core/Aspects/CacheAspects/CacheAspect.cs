using System;
using System.Linq;
using Thoth.Framework.Core.CrossCuttingConcern.Caching.Microsoft;
using PostSharp.Aspects;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Thoth.Framework.Core.Aspects.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private readonly int _dakika;

        /// <param name="bitisSuresi">Cache işleminin dakika olarak ömrü (standart 60 dakikadır)</param>
        public CacheAspect(int bitisSuresi = 60)
        {
            _dakika = bitisSuresi;
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {

            //cache manager türetiliyor
            var cacheManager = new MemoryCacheManager();

            //metod ismi alınıyor
            var methodName = string.Format("{0}.{1}.{2}",
                                     args.Method.ReflectedType.Namespace,
                                     /*args.Method.ReflectedType.Name*/args.Instance.ToString(),
                                     args.Method.Name);

            //metod parametreleri alınıyor
            var arguments = args.Arguments.ToList();


            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(JsonConvert.SerializeObject(arguments)));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }


            string key =  string.Format("{0}({1})", methodName, strBuilder);


            //metod cache de var ise oradan çağrılıyor
            if (cacheManager.IsAdd(key))
            {
                args.ReturnValue = cacheManager.Get<object>(key);
                return;
            }

            //metod çalıştırılıyor
            base.OnInvoke(args);

            //metod cache ekleniyor
            cacheManager.Add(key, args.ReturnValue, _dakika);
        }
        
    }
}
