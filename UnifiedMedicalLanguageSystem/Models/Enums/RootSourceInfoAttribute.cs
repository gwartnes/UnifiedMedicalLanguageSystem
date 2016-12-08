using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedMedicalLanguageSystem
{
    [AttributeUsage(AttributeTargets.Field)]
    sealed class RootSourceInfoAttribute : Attribute
    {
        private readonly string _code;
        public RootSourceInfoAttribute(string code)
        {
            _code = code;
        }
        public string Code { get { return _code; } }
        public string SourceName { get; set; }
    }

    public static class EnumExtensions
    {
        public static string GetSourceAbbreviation(this RootSource rootSource)
        {
            var attribute = typeof(RootSource);
            var fieldInfo = attribute.GetRuntimeField(rootSource.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(RootSourceInfoAttribute));
            if (attributes != null && attributes.Count() > 0)
            {
                return ((RootSourceInfoAttribute)attributes.First()).Code;
            }
            return rootSource.ToString();
        }
    }
}
