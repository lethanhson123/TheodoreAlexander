using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using DAL.ViewModels;
using System.Net.Http;
using System.ServiceModel.Channels;

namespace TA_Web_2020_API.Helper
{
    public class Helper
    {
        public JWTAuthenIdentity GetCurrentThreadIdentity()
        {
            return Thread.CurrentPrincipal.Identity as JWTAuthenIdentity;
        }
        public JWTIdentityViewModel GenerateJWTViewModel()
        {
            try
            {
                JWTAuthenIdentity model = GetCurrentThreadIdentity();
                JWTIdentityViewModel viewModel = new JWTIdentityViewModel
                {
                    UserId = BL.Helper.TryParseStringToGuid(model.UserId),
                    UserName = model.UserName,
                    AccountNumber = model.AccountNumber,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserType = model.UserType,
                    CountryId = BL.Helper.TryParseStringToGuid(model.CountryId),
                    Country = model.Country,
                    CountryFullName = model.CountryFullName,
                    Region = model.Region.ToUpper(),
                    ContinentId = BL.Helper.TryParseStringToGuid(model.ContinentId),
                    IsShowInStock = model.IsShowInStock,
                    ExclusivityGroupId = BL.Helper.TryParseStringToGuid(model.ExclusivityGroupId),
                    RequestIpAddress = model.RequestIpAddress,
                    ResponseIpAddress = model.ResponseIpAddress
                };
                return viewModel;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public static string GetClientIp(HttpRequestMessage request = null)
        {
            if (request == null)
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
