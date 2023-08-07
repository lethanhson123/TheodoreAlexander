using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TA_Web_2020_API.Models;

namespace TA_Web_2020_API.Helper
{
    public class GenerateResponeHelper<T>: IHttpActionResult
    {
        private static T _value;
        private static HttpRequestMessage _request;
        private static HttpStatusCode _code;
        private static bool _success;
        public GenerateResponeHelper(T value, bool Success, HttpRequestMessage Request, HttpStatusCode Code)
        {
            _value = value;
            _request = Request;
            _code = Code;
            _success = Success;
        }
        public static HttpResponseMessage GenerateResponse() {
            ResponseModel<T> rp = new ResponseModel<T>
            {
                Success = _success,
                StatusCode = (int)_code,
                Data = _value
            };
            HttpResponseMessage response = _request.CreateResponse(HttpStatusCode.OK, rp);
            return response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = GenerateResponse();
            return Task.FromResult(response);
        }
    }
}