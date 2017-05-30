using System;
using System.Configuration;
using Thoth.Framework.Core.Utilities.ExtensionMethods;
using Ninject;
using Ninject.Modules;

namespace Thoth.Business.DependencyResolvers.Ninject
{
    public class ResolveModule : NinjectModule
    {
        public override void Load()
        {
            var soaSetting = ConfigurationManager.AppSettings["SOA"];

            var soa = !string.IsNullOrEmpty(soaSetting) && soaSetting.ToBoolean();

            if (soa)
            {
                Kernel.Load(new ServiceModule());
            }
            else
            {
                Kernel.Load(new BusinessModule());
            }
        }
    }
}
