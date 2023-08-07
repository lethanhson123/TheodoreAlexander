using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace TA_Web_2020_API.Helper
{
    public static class CheckApiUrl
    {
        public static bool IsPublicApi(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.StartsWith("/public");
        }
        public static bool IsSwaggerUrl(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.StartsWith("/swagger");
        }

        public static bool IsTestUrl(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.StartsWith("/test");
        }
        public static bool IsLocalUrl(HttpRequestMessage request)
        {
            return request.IsLocal();
        }
    }
}