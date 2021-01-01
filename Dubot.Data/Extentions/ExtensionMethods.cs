using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dubot.Data.Exceptions
{
    public static class ExtensionMethods
    {
        public static int ValidateSave(this DbContext context)
        {
            try
            {
                return context.SaveChanges();
            }
            catch (ValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                throw newException;
            }
        }

        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static string Sanitize(this string s)
        {
            s = s.Replace("'", "")
                .RemoveSpecialChars();

            return s;
        }

        public static string RemoveSpecialChars(this string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if ((c >= '0' && c <= '9')
                    || (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || c == '.' || c == '_'
                    || c == '[' || c == ']' || c == '|')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
