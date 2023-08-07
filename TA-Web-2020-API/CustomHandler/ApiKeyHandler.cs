using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TA_Web_2020_API.Models;
using TA_Web_2020_API.Helper;

namespace TA_Web_2020_API.CustomHandler
{
    public class ApiKeyHandler: DelegatingHandler
    {
        //this is only test api key
        //we have get api in db
        private const string apiKey = "X-some-key";
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //no require key for swagger and test get api
            if (CheckApiUrl.IsSwaggerUrl(request) || CheckApiUrl.IsTestUrl(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            bool isValidAPIKey = false;
            //Validate that the api key exists

            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out IEnumerable<string> lsHeaders);

            if (checkApiKeyExists)
            {
                isValidAPIKey = ValidateKey(lsHeaders.FirstOrDefault());
            }

            //If the key is not valid, return an http status code.
            if (!isValidAPIKey)
            {
                ResponseModel<string> rp = new ResponseModel<string>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Data = "Invalid Api key"
                };
                var response = request.CreateResponse(HttpStatusCode.OK, rp);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return await tsc.Task;
            }

            return await base.SendAsync(request, cancellationToken);
        }
        private bool ValidateKey(string headerKey)
        {
            return (headerKey == apiKey);
        }
    }
}