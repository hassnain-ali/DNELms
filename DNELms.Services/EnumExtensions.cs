using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DNELms.Services
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectList> AsEnumerable<T>(this T @enum) where T : struct, Enum
        {
            try
            {
                return Enum.GetValues<T>().Select(s => new SelectList { Id = Convert.ToInt16(s), Value = s.ToString(), Display = s.GetDisplayValue() });
            }
            catch { }
            return Enumerable.Empty<SelectList>();
        }
        public static string GetDisplayValue<T>(this T value) where T : struct, Enum
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes.Length > 0)
                {
                    return string.IsNullOrWhiteSpace(descriptionAttributes[0].Name) ? value.ToString() : descriptionAttributes[0].Name;
                }
                return value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public record SelectList
        {
            public short Id { get; set; }
            public string Value { get; set; }
            public string Display { get; set; }
        }
    }
}
