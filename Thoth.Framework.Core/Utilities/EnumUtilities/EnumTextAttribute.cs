﻿using System;

namespace Thoth.Framework.Core.Utilities.EnumUtilities
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumTextAttribute : Attribute
    {
        public string Text { get; set; }
    }
}
