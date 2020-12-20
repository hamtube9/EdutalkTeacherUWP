using EdutalkTeacherUWP.Api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EdutalkTeacherUWP.Api.Authorization
{
    public interface IAuthHeaderManager
    {
        Task<T> GetAuthHeaderAsync<T>(string key);
        Task<T> GetAuthHeaderAsync<T>();
        Task<bool> SetAuthHeaderAsync<T>(string key, T header);
        Task<bool> SetAuthHeaderAsync<T>(T header);
    }

    public class AuthHeaderManager : IAuthHeaderManager
    {
        ApplicationDataContainer localSettings { set; get; }
        public AuthHeaderManager()
        {
             localSettings = ApplicationData.Current.LocalSettings;
        }
        public static string AuthHeaderNewKey = "_Edutalk_AuthHeaderKey_";
        public Task<T> GetAuthHeaderAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Task.FromResult(default(T));
            }
            return Task.FromResult(((string)localSettings.Values[key]).DeserializeObject<T>());
        }

        public Task<T> GetAuthHeaderAsync<T>()
        {
            return GetAuthHeaderAsync<T>(AuthHeaderNewKey);
        }


        public Task<bool> SetAuthHeaderAsync<T>(string key, T header)
        {
            if (string.IsNullOrEmpty(key))
            {
                return Task.FromResult(false);
            }
            if (header == null)
            {
                localSettings.Values.Remove(key);
                return Task.FromResult(true);
            }
            localSettings.Values[key] = header.SerializeObject();
            return Task.FromResult(true);
        }

        public Task<bool> SetAuthHeaderAsync<T>(T header)
        {
            return SetAuthHeaderAsync(AuthHeaderNewKey, header);
        }
    }
}
