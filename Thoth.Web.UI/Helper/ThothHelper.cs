using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Thoth.Web.UI.Helper
{
    public class ThothHelper
    {
        public static string GetThemeUrl()
        {
            return ConfigurationManager.AppSettings["ThemeUrl"];
        }

    }
}
