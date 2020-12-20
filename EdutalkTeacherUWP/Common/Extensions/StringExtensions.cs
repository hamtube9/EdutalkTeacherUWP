using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Common.Extensions
{
    public static class StringExtensions
    {
        public static T DeserializeObject<T>(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return default(T);
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch
            {
                return default(T);
            }
        }

        public static string SerializeObject<T>(this T obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static DateTime ToNormalDateTime(this string time, string pattern = null, int expandTime = 0)
        {
            if (string.IsNullOrEmpty(time))
            {
                return DateTime.Now;
            }
            try
            {
                return DateTime.ParseExact(time, pattern ?? "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return DateTime.Now.AddMinutes(expandTime);
            }
        }

        public static bool IsEmailValid(this string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;
            if ((Regex.Match(address, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"((([0-9a-zA-Z][-0-9a-zA-Z]*[0-9a-zA-Z]*\.)+[a-z0-9A-Z][\-a-z0-9A-Z]{0,22}[a-z0-9A-Z]))$").Success && (!string.IsNullOrWhiteSpace(address))))
                return true;
            return false;
        }

        public static bool IsPhoneNumberValid(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            return Regex.Match(phone, @"^[0-9]{6,13}$").Success;
        }

        public static string ToEndStr(this DateTime d)
        {
            if (d.Minute == 0)
            {
                return $"{d:H'h'}";
            }
            return $"{d:H'h'mm}";
        }

        public static string ToStartStr(this DateTime d)
        {
            if (d.Minute == 0)
            {
                return $"{d:HH}";
            }
            return $"{d:H'h'mm}";
        }

        public static async Task<Stream> LoadAudio(this string url)
        {
            var uri = new Uri(url);
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);
            return await response.Content.ReadAsStreamAsync();
        }

        public static bool IsPhoneValid(this string ph)
        {
            if (ph == null || string.IsNullOrWhiteSpace(ph))
                return false;
            return Regex.Match(ph, @"^[0-9]{6,13}$").Success;
        }

        public static bool IsNumber(this string ph)
        {
            if (ph == null || string.IsNullOrWhiteSpace(ph))
                return false;
            return Regex.Match(ph, @"^[0-9]+$").Success;
        }

        public static (string lastName, string firstName) SplitName(this string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return (string.Empty, string.Empty);
            }

            var arr = fullName.Replace("  ", " ").Trim().Split(' ');
            if (arr.Length == 0)
            {
                return (string.Empty, string.Empty);
            }
            if (arr.Length == 1)
            {
                return (arr[0], string.Empty);
            }
            return (arr[0], arr.Skip(1).Aggregate((d1, d2) => d1 + " " + d2));
        }
    }
}
