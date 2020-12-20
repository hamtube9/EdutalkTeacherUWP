using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Utils
{
    public class RefitSetting
    {
        public static JsonSerializerSettings SnakeCaseSettings => new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public static RefitSettings SnakeCaseNaming => new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(SnakeCaseSettings)
        };

        public static RefitSettings CamelCaseNaming => new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            })
        };
    }
}
