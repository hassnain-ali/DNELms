
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DNELms.Services
{
    public static class StringExtentions
    {
        /// <summary>
        /// Gets the length of string after trim
        /// </summary>
        /// <param name="helper"></param>
        /// <returns>Int32</returns>
        public static int TrimLength(this String helper)
        {
            return helper.Trim().Length;
        }
        /// <summary>
        ///  Returns the matched string from the regex pattern.The groupName is for named group match values in the form(?<name>group).
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <param name="groupName"></param>
        /// <returns>String</returns>
        public static string RegexMatch(this String helper, string pattern, RegexOptions options, string groupName)
        {
            if (groupName.In(null))
                return Regex.Match(helper, pattern, options).Value;
            else
                return Regex.Match(helper, pattern, options).Groups[groupName].Value;
        }
        /// <summary>
        /// Match Regex in string
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static string RegexMatch(this String helper, string pattern)
        {
            return RegexMatch(helper, pattern, RegexOptions.None, null);
        }
        /// <summary>
        /// Match Regex in string with options
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string RegexMatch(this String helper, string pattern, RegexOptions options)
        {
            return RegexMatch(helper, pattern, options, null);
        }
        /// <summary>
        /// Match Regex in string
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static string RegexMatch(this String helper, string pattern, string groupName)
        {
            return RegexMatch(helper, pattern, RegexOptions.None, groupName);
        }

        /// <summary>
        ///  Returns true if there is a match from the regex pattern
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns>true if match</returns>
        public static bool IsRegexMatch(this String helper, string pattern, RegexOptions options)
        {
            return helper.RegexMatch(pattern, options).Length > 0;
        }
        /// <summary>
        /// Returns true if there is a match from the regex pattern
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pattern"></param>
        /// <returns>true if match</returns>
        public static bool IsRegexMatch(this String helper, string pattern)
        {
            return helper.IsRegexMatch(pattern, RegexOptions.None);
        }

        /// <summary>
        /// Returns a string where matching patterns are replaced by the replacement string.
        /// </summary>
        /// <param name="pattern">The regex pattern for matching the items to be replaced</param>
        /// <param name="replacement">The string to replace matching items</param>
        /// <returns>string</returns>
        public static string RegexReplace(this String helper, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(helper, pattern, replacement, options);
        }
        /// <summary>
        /// Returns a string where matching patterns are replaced by the replacement string.
        /// </summary>
        /// <param name="pattern">The regex pattern for matching the items to be replaced</param>
        /// <param name="replacement">The string to replace matching items</param>
        /// <returns>string</returns>
        public static string RegexReplace(this String helper, string pattern, string replacement)
        {
            return Regex.Replace(helper, pattern, replacement, RegexOptions.None);
        }


        /// <summary>
        /// "abc".IsLike("a*"); // true
        ///"Abc".IsLike("[A-Z][a-z][a-z]"); // true
        ///"abc123".IsLike("*###"); // true
        ///"hat".IsLike("?at"); // true
        ///"joe".IsLike("[!aeiou]*"); // true
        ///"joe".IsLike("?at"); // false
        ///"joe".IsLike("[A-Z][a-z][a-z]"); // false
        /// </summary>
        /// <param name="s">value from</param>
        /// <param name="wildcardPattern">value to compare with</param>
        /// <returns>True if match any of these</returns>
        public static bool IsLike(this string s, string wildcardPattern)
        {
            if (s == null || String.IsNullOrEmpty(wildcardPattern)) return false;

            s = string.Concat(s.ToLower());
            wildcardPattern = string.Concat(wildcardPattern.ToLower());
            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            bool result;
            try
            {
                result = Regex.IsMatch(s, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(String.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }
            return result;
        }
        /// <summary>
        /// capitalize string
        /// like "ali" to "Ali" or "hassnain ali" to "Hassnain Ali"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Capitalize(this string str)
        {
            if (str.Length == 0)
                return str;
            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }
        public static string FirstName(this string name, string spliter = " ")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return name;
            }
            return name.Split(spliter)[0];
        }
        public static string LastName(this string name, string spliter = " ")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                return name.Split(spliter)[1];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static string RemoveLastCharacter(this String instr)
        {
            return instr[0..^1];
        }
        public static string RemoveLast(this String instr, int number)
        {
            return instr[0..^number]; //instr.Substring(0, instr.Length - number);
        }
        public static string RemoveFirstCharacter(this String instr)
        {
            return instr[1..];
        }
        public static string RemoveFirst(this String instr, int number)
        {
            return instr[number..];
        }
        /// <summary>
        /// counts total words in string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
        /// <summary>
        /// counts the letters occurance in string
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static int Occurrence(this String instr, string search)
        {
            return Regex.Matches(instr, search).Count;
        }
        public static string Join<T>(this IEnumerable<T> self, string separator)
        {
            return String.Join(separator, self.Select(e => e.ToString()).ToArray());
        }

        public static string Join(this Array array, string separator)
        {
            return String.Join(separator, array);
        }

        public static double NullToZeroReplace(this object value)
        {
            //double result = String.IsNullOrEmpty(Convert.ToString(value)) ? 0 : Convert.ToDouble(value);
            //if (!Double.IsNaN(result) && !Double.IsInfinity(result))
            //    return Math.Round(Convert.ToDouble(result), 2);
            //else
            //    return 0;

            return String.IsNullOrEmpty(Convert.ToString(value)) ? 0 : Convert.ToDouble(value);
        }
        public static double NullToZeroReplace(this string value)
        {
            if (!ReferenceEquals(value, null) && value.Contains(","))
            {
                value = value.Replace(",", "");
            }

            return String.IsNullOrEmpty(Convert.ToString(value)) ? 0 : Convert.ToDouble(value);
        }
        public static string NullToEmptyReplace(this string value)
        {
            return String.IsNullOrWhiteSpace(Convert.ToString(value)) ? string.Empty : value;
        }
        public static string ToString(this object value)
        {
            return Convert.ToString(value);
        }
        public static string Truncate(this string str, int length)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            return str.Length <= length ? str : str[0..^4] + " ...";
        }
        /// <summary>
        /// Replace with given value if first value is null or whitespace
        /// </summary>
        /// <param name="val">value to be check</param>
        /// <param name="with">value to replace with</param>
        /// <returns>Finalized value after replacing if required</returns>
        public static string ReplaceIfNull(this string val, string with) => string.IsNullOrWhiteSpace(val) ? with : val;
        public static string FetchFileName(this string fileName, string path, bool isUnique)
        {
            if (isUnique)
            {
                return path.FetchUniquePath(fileName);
            }
            return fileName;
        }
        public static string ToNullableLower(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            return str.ToLower();
        }
        /// <summary>
        /// Gets Avatar text. if "abc xyz" then return "AX"
        /// </summary>
        /// <param name="val">Give value in it to get</param>
        /// <returns>Avatar Value</returns>
        public static string GetAvatar(this string val)
        {
            string avatar = string.Empty;
            try
            {
                foreach (var item in val.Split(' '))
                {
                    avatar += item[0];
                }
                return avatar.ToUpper().Trim();
            }
            catch (Exception)
            {

            }
            return avatar;
        }
        public static string FetchUniquePath(this string path, string fileName)
        {
            return string.Concat(DateTime.Now.Ticks, DateTime.UtcNow.Ticks, Path.GetExtension(fileName));
        }
    }
}
