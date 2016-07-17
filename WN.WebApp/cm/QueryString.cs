using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WN.WebApp.cm
{
    public static class QueryString
    {
        static char[] illegal_Character = { '<', '>', '*', '%', '&', ':', '?','.','_' };
        public static string ValidateQueryString(string query)
        {
            foreach (char item in illegal_Character)
            {
                while (query.Contains(item))
                    query = query.Replace(item, ' ');
            }
            query = query.Trim();
            while (query.IndexOf("  ") >= 0)
                query = query.Replace("  ", " ");

            while (query.IndexOf(" ") >= 0)
                query = query.Replace(" ", "-");
            return query.ToLower();
        }
        //static public string UpperCaseFirstCharacter(this string s)
        //{
        //    // Check for empty string.
        //    if (string.IsNullOrEmpty(s))
        //    {
        //        return string.Empty;
        //    }
        //    // Return char and concat substring.
        //    return char.ToUpper(s[0]) + s.Substring(1);
        //}

        static public string UpperCaseFirstCharacter(this string text)
        {
            text = text.ToLower();
            return Regex.Replace(text, "^[a-z]", m => m.Value.ToUpper());
        }
    }
}