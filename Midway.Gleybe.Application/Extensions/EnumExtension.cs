using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midway.Gleybe.Application.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(description);

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs.First()).Description;
                }
            }

            return description;
        }
    }
}
