using System;
using System.Security.Principal;

namespace Thoth.Framework.Core.CrossCuttingConcern.Security.Web
{
    [Serializable]
    public class MyIdentity : IIdentity
    {
        public string SessionId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}