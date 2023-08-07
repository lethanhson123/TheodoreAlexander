using BL.CustomExceptions;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TA_Web_2020_API.Helper;
using TA_Web_2020_API.Models;

namespace TA_Web_2020_API.CustomHandler
{
    public class IpAddresshandler: DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (CheckApiUrl.IsSwaggerUrl(request))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            var checkIpAddressExists = request.Headers.TryGetValues("Ip_Address", out IEnumerable<string> lsHeaders);
            string ipAddress;
            if (checkIpAddressExists)
            {
                ipAddress = lsHeaders.FirstOrDefault();
            }
            else
            {
                ipAddress = GetClientIp(request);
            }
            if (string.IsNullOrEmpty(ipAddress))
            {
                ResponseModel<string> rp = new ResponseModel<string>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Data = "Null IP"
                };
                var response = request.CreateResponse(HttpStatusCode.OK, rp);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return await tsc.Task;
            }
            bool? IsSiteAccessAllowed = await ValidateIpAddress(ipAddress, request);
            if( IsSiteAccessAllowed == null)
            {
                ResponseModel<string> rp = new ResponseModel<string>
                {
                    Success = false,
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Data = ipAddress
                };
                var response = request.CreateResponse(HttpStatusCode.OK, rp);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return await tsc.Task;
            }
            else
            {
                //If the ip address is not allowed, return an http status code.
                if (!(bool)IsSiteAccessAllowed)
                {
                    ResponseModel<string> rp = new ResponseModel<string>
                    {
                        Success = false,
                        StatusCode = (int)HttpStatusCode.Forbidden,
                        Data = "Access denied " + ipAddress
                    };
                    var response = request.CreateResponse(HttpStatusCode.OK, rp);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return await tsc.Task;
                }
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<bool?> ValidateIpAddress(string ipAddress, HttpRequestMessage request)
        {
            try
            {
                var _generalServices = request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(BL.BusinessService.GeneralBusinessService)) as BL.BusinessService.GeneralBusinessService;
                return await _generalServices.IsSiteAccessAllowed(ipAddress);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        private string GetClientIp(HttpRequestMessage request = null)
        {
            if(request == null)
            {
                return null;
            }

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }
    }
}