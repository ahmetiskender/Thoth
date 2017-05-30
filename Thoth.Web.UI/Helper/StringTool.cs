using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Thoth.Web.UI.Helper
{
    public static class StringTool
    {

        public static Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }
        /// <summary>
        /// Deletes some lines from the source string.
        /// </summary>
        /// <param name="s">Source string</param>
        /// <param name="linesToRemove">Number lines to remove.</param>
        /// <returns>String with removed N lines</returns>
        /// <summary>
        /// Deletes some lines from the source string.
        /// </summary>
        /// <param name="s">Source string</param>
        /// <param name="linesToRemove">Number lines to remove.</param>
        /// <returns>String with removed N lines</returns>
        public static string DeleteLines(string s, int linesToRemove)
        {
            return s.Split(Environment.NewLine.ToCharArray(),
                           linesToRemove + 1,
                           StringSplitOptions.RemoveEmptyEntries
                ).Skip(linesToRemove)
                .FirstOrDefault();
        }

        /// <summary>
        /// Get a substring of the first N characters.
        /// </summary>
        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        /// <summary>
        /// Get a substring of the first N characters. [Slow]
        /// </summary>
        public static string Truncate2(string source, int length)
        {
            return source.Substring(0, Math.Min(length, source.Length));
        }

        /// <summary>
        /// Return random string by specific length.
        /// </summary>
        /// <param name="length">String length.</param>
        /// <param name="NumbersOnly">Numbers only flag.</param>
        /// <returns>String with specified length.</returns>
        public static string RandomString(int length, bool NumbersOnly = false)
        {
            string allowedChars;

            if (NumbersOnly)
                allowedChars = "0123456789";
            else
                allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = allowedChars.ToCharArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }

    }
}
