using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thoth.Framework.Core.CrossCuttingConcern.Security.Authorization;
using PostSharp.Aspects;

namespace Thoth.Framework.Core.Aspects.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation:OnMethodBoundaryAspect
    {
        private string _roles;
        AuthorizationService _authorizationService;
        public SecuredOperation(string roles)
        {
            _roles = roles;
        }


        public override void OnEntry(MethodExecutionArgs args)
        {
            
        }
    }
}
