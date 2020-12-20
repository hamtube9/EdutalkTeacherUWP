using EdutalkTeacherUWP.Api.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Extensions
{
    public static class TokenExtensions
    {
        public static async Task<string> GetBearerToken(this IAuthHeaderManager authHeader)
        {
            var token = await authHeader.GetAuthHeaderAsync<Token>();
            return token?.AccessToken;
        }
    }
}
