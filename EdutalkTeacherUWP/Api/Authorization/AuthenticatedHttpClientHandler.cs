using EdutalkTeacherUWP.Api.Base;
using HttpTracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Authorization
{
    public class AuthenticatedHttpClientHandler : HttpTracerHandler
    {
        readonly Func<Task<string>> getToken;

        public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
            : base()
        {
            this.getToken = getToken ?? throw new ArgumentNullException(nameof(getToken));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;

            var token = await getToken().ConfigureAwait(false);
            if (auth != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme ?? ApiBase.BearerScheme, token);
            }
            else
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(ApiBase.BearerScheme, token);
            }
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
