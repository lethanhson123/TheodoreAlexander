using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TA_Web_2020_API.CustomHandler
{
    /*
     * public class CrossDomainHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Options)
            {
                var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();

                var controllerRequested = request.GetRouteData().Values["controller"] as string;
                var supportedMethods = apiExplorer.ApiDescriptions.Where(d =>
                {
                    var controller = d.ActionDescriptor.ControllerDescriptor.ControllerName;
                    return string.Equals(
                        controller, controllerRequested, StringComparison.OrdinalIgnoreCase);
                })
                .Select(d => d.HttpMethod.Method)
                .Distinct();

                if (!supportedMethods.Any())
                    return Task.Factory.StartNew(
                        () => request.CreateResponse(HttpStatusCode.NotFound));

                return Task.Factory.StartNew(() =>
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.OK);
                    resp.Headers.Add("Access-Control-Allow-Origin", "*");
                    resp.Headers.Add(
                        "Access-Control-Allow-Methods", string.Join(",", supportedMethods));

                    return resp;
                });
            }

            return base.SendAsync(request, cancellationToken);

        }
    }
    */
    public class CrossDomainHandler : DelegatingHandler
    {
        const string Origin = "Origin";
        const string AccessControlRequestMethod = "Access-Control-Request-Method";
        const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isCorsRequest = request.Headers.Contains(Origin);
            bool isPreflightRequest = request.Method == HttpMethod.Options;
            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    return await Task.Factory.StartNew(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

                        string accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                        if (accessControlRequestMethod != null)
                        {
                            response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
                        }

                        string requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                        if (!string.IsNullOrEmpty(requestedHeaders))
                        {
                            response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                        }

                        return response;
                    }, cancellationToken);
                }
                else
                {
                    return await base.SendAsync(request, cancellationToken).ContinueWith(t =>
                    {
                        HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                        if (t.Result != null)
                        {
                            resp = t.Result;
                            //string accessControlAllowOrigin = resp.Headers.GetValues(AccessControlAllowOrigin).FirstOrDefault();
                            var resCors = resp.Headers.TryGetValues(AccessControlAllowOrigin, out IEnumerable<string> lsHeaders);
                            if (!resCors)
                            {
                                resp.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
                            }
                            //if (accessControlAllowOrigin == null)
                            //{
                            //    resp.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
                            //}
                        }

                        //Workaround to fix case of error (not 200 code), sometime front end get CORS error instead of error/exception message
                        //Workaround by sleeping can fix this issue 
                        HttpResponseMessage resContent = JsonConvert.DeserializeObject<HttpResponseMessage>(t.Result.Content.ReadAsStringAsync().Result);
                        if (resContent.StatusCode != HttpStatusCode.OK)
                        {
                            //only sleep if it got error (not 200 code)
                            Thread.Sleep(3000);
                        }

                        return resp;
                    });
                }
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}