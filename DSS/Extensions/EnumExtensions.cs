using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DSS.Extensions
{
    public static class EnumExtensionss
    {
        public static string FriendlyName(this Enum enumValue)
        {
            return enumValue.GetType()
                    .GetMember(enumValue.ToString())
                    .First()
                    .GetCustomAttribute<DisplayAttribute>()
                    .GetName();
        }
    }
}