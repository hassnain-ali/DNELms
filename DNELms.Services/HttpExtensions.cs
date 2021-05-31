using DNELms.Core.Infrastructure;
using DNELms.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace DNELms.Services
{
    public static class HttpExtensions
    {
        public static PagingVM FetchPaging(this HttpRequest request)
        {
            PagingVM paging = new(0);
            try
            {
                IQueryCollection query = request.Query;
                string range = query["range"];
                string sort = query["sort"];
                string filter = query["filter"];
                int[] resultRange = JsonSerializer.Deserialize<int[]>(range);
                //string filterData = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(filter);
                paging.DisplayStart = resultRange.FirstOrDefault();
                paging.DisplayLength = resultRange.LastOrDefault();
                string[] resultOrder = JsonSerializer.Deserialize<string[]>(sort);
                paging.SortCol = resultOrder.First();
                paging.SortOrder = resultOrder.Last();
                //paging.Query = filterData;
                return paging;
            }
            catch
            {
                return paging;
            }
        }
        public static object ToDBQuery(this PagingVM paging)
        {
            return new { paging.DisplayLength, paging.DisplayStart, paging.SortCol, paging.SortOrder, paging.Query };
        }
        public static string ToQueryString(this NameValueCollection nvc)
        {
            return string.Join("&",
                nvc.AllKeys.Select(
                    key => string.Format("{0}={1}",
                        HttpUtility.UrlEncode(key),
                        HttpUtility.UrlEncode(nvc[key]))));
        }
        public static async Task<string> UploadFileAsync(this IFormFile file, string path, bool isUniqueFileName = true)
        {
            try
            {
                var environment = EngineContext.Current.Resolve<IHostingEnvironment>();
                string wwwPath = environment.WebRootPath;
                string tempwebpAddress = wwwPath + "\\" + "temp\\" + DateTime.UtcNow.Ticks + DateTime.Now.Ticks + ".webp";
                //Image image = default;

                string fullPath = string.Concat(wwwPath, path.Replace("/", "\\"));
                string fileName = string.Concat(Path.GetFileNameWithoutExtension(file.FileName.NullToEmptyReplace()), file.FileName.FetchFileName(fullPath, isUniqueFileName)).ReplaceUnnessessory();
                string fullPathFileName = string.Concat(fullPath, fileName);
                //await file.CopyToAsync(memoryStream);
                //image = Image.FromStream(imageStream);

                using var memoryStream = new FileStream(fullPathFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                await file.CopyToAsync(memoryStream);

                return fileName;
            }
            catch (Exception ex)
            {
                // EngineContext.Current.Resolve<ISQLFactory>().ErrorLog(ex, "File Uploader with watermark settings");
                return "";
            }
        }
        public static string RemoveWhiteSpace(this string XML)
        {
            return Regex.Replace(XML, @"\s+", "");
        }
        public static string ReplaceUnnessessory(this string XML)
        {
            return XML.RemoveWhiteSpace().Replace("(", "-").Replace(")", "-").Replace("{", "-").Replace("}", "-").Replace("[", "-").Replace("]", "-").Replace("#", "-");
        }
        public static void IfType<T>(this object item, Action<T> action) where T : class
        {
            if (item is T)
            {
                action(item as T);
            }
        }
        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException(nameof(source));
            return list.Contains(source);
        }

        public static IEnumerable<PropertyInfo> GetAllProperties<T>(this T obj, string toSkip = "") where T : new()
        {
            return typeof(T).GetProperties().Where(s => !s.Name.In(toSkip));
        }
        public static object GetSpecificPropertyValue<T>(this T obj, string prop)
        {
            return typeof(T).GetProperties().First(s => s.Name.ToLower().Contains(prop.ToLower())).GetValue(obj);
        }
        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(this Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(this Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// same as python 'join'
        /// </summary>
        /// <typeparam name="T">list type</typeparam>
        /// <param name="separator">string separator </param>
        /// <param name="list">list of objects to be ToString'd</param>
        /// <returns>a concatenated list interleaved with separators</returns>
        static public string Join<T>(this string separator, IEnumerable<T> list)
        {
            var sb = new StringBuilder();
            bool first = true;

            foreach (T v in list)
            {
                if (!first)
                    sb.Append(separator);
                first = false;

                if (v != null)
                    sb.Append(v.ToString());
            }

            return sb.ToString();
        }


        private static readonly Dictionary<Type, MethodInfo> Parsers = new Dictionary<Type, MethodInfo>();


        /// <summary>
        /// var hundredTwentyThree = "123".Parse(0);
        /// var badnumber = "test".Parse(-1);</summary>
        /// var date = "01/01/01".Parse<DateTime>();
        /// <typeparam name="T">any type</typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns>result after parsing</returns>
        public static T Parse<T>(this string value, T defaultValue = default)
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;

            if (!Parsers.ContainsKey(typeof(T)))
                Parsers[typeof(T)] = typeof(T).GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .Where(mi => mi.Name == "TryParse")
                    .Single(mi =>
                    {
                        var parameters = mi.GetParameters();
                        if (parameters.Length != 2) return false;
                        return parameters[0].ParameterType == typeof(string) &&
                       parameters[1].ParameterType == typeof(T).MakeByRefType();
                    });

            var @params = new object[] { value, default(T) };
            return (bool)Parsers[typeof(T)].Invoke(null, @params) ?
                (T)@params[1] : defaultValue;
        }

        public static T Safe<T>(this T obj) where T : new()
        {
            if (obj == null)
            {
                obj = new T();
            }

            return obj;
        }
    }
}
