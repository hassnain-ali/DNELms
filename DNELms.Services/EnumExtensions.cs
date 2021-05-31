using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace DNELms.Services
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectList> AsEnumerable<T>(this T @enum) where T : Enum
        {
            try
            {
                IEnumerable<T> values = Enum.GetValues(typeof(T)).Cast<T>();
                return values.Select(s => new SelectList { Id = Convert.ToInt16(s), Value = s.ToString(), Display = GetDisplayValue(s) });
            }
            catch { }
            return Enumerable.Empty<SelectList>();
        }
        public static string GetDisplayValue<T>(T value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes[0].ResourceType != null)
                    return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            var resourceKeyProperty = resourceManagerProvider.GetProperty(resourceKey,
                BindingFlags.Static | BindingFlags.Public, null, typeof(string),
                Array.Empty<Type>(), null);
            if (resourceKeyProperty != null)
            {
                return (string)resourceKeyProperty.GetMethod.Invoke(null, null);
            }

            return resourceKey; // Fallback with the key name
        }
        public record SelectList
        {
            public short Id { get; set; }
            public string Value { get; set; }
            public string Display { get; set; }
        }
    }
}
