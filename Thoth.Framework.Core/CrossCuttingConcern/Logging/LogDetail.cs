using System.Collections.Generic;
using Thoth.Framework.Core.Aspects.LogAspects;

namespace Thoth.Framework.Core.CrossCuttingConcern.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}