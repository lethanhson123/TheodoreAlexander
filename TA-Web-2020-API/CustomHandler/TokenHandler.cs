using DAL.ViewModels;
using Newtonsoft.Json;
using Nito.AsyncEx;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TA_Web_2020_API.Helper;
using TA_Web_2020_API.Models;

namespace TA_Web_2020_API.CustomHandler
{
    public class TokenHandler : DelegatingHandler
    {
        private static readonly JsonWebTokenModule jwtModule = new JsonWebTokenModule();
        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            JWTAuthenIdentity identity;
            ClaimsPrincipal claim;
            string token;
            try
            {
                if (CheckApiUrl.IsPublicApi(request) || CheckApiUrl.IsSwaggerUrl(request))
                {
                    return await base.SendAsync(request, cancellationToken);
                }
                //fetch token in header
                token = FetchHeader(request);

                //If token is null, generate default token for anonymous user
                if (String.IsNullOrEmpty(token) || token == "null")
                {
                    token = await jwtModule.GenerateToken(Guid.Empty, request);
                    claim = jwtModule.GetPrincipal(token);
                    identity = jwtModule.GenerateIdentity(claim);
                }
                else
                {
                    //verify current token and create new one if needed
                    claim = jwtModule.GetPrincipal(token);
                    identity = jwtModule.GenerateIdentity(claim);
                    if (identity != null)
                    {
                        //check dirty and refresh token if needed
                        var newToken = await jwtModule.GenerateToken(Guid.Parse(identity.UserId), request);
                        var newClaim = jwtModule.GetPrincipal(newToken);
                        var newIdentity = jwtModule.GenerateIdentity(newClaim);
                        if (JWTAuthenIdentity.IsDirtyIdentity(identity, newIdentity)) {
                            token = newToken;
                            claim = newClaim;
                            identity = newIdentity;
                        }
                    }
                    else {
                        //generate default token for anonymous user
                        token = await jwtModule.GenerateToken(Guid.Empty, request);
                        claim = jwtModule.GetPrincipal(token);
                        identity = jwtModule.GenerateIdentity(claim);
                    }
                }
                //Add principal to thread, context
                SetPrincipal(identity);
                //Add token in header response
                HttpResponseMessage responseCustom = await base.SendAsync(request, cancellationToken);
                responseCustom.Headers.Add("Token", token);
                return responseCustom;
            }
            catch (Exception e)
            {
                token = await jwtModule.GenerateToken(Guid.Empty, request);
                claim = jwtModule.GetPrincipal(token);
                identity = jwtModule.GenerateIdentity(claim);
                SetPrincipal(identity);
                HttpResponseMessage responseCustom = await base.SendAsync(request, cancellationToken);
                responseCustom.Headers.Add("Token", token);
                return responseCustom;
            }
        }

        private string FetchHeader(HttpRequestMessage request)
        {
            string token = null;
            var authRequest = request.Headers.Authorization;
            if (authRequest != null)
            {
                token = authRequest.Parameter;
            }
            return token;
        }
        private void SetPrincipal(JWTAuthenIdentity identity)
        {
            var genericPrincipal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = genericPrincipal;
            if (Thread.CurrentPrincipal.Identity is JWTAuthenIdentity authenticationIdentity)
            {
                authenticationIdentity.CountryId = identity.CountryId;
                authenticationIdentity.UserId = identity.UserId;
                authenticationIdentity.UserName = identity.UserName;
                authenticationIdentity.Email = identity.Email;
                authenticationIdentity.FirstName = identity.FirstName;
                authenticationIdentity.LastName = identity.LastName;
                authenticationIdentity.UserType = identity.UserType;
                authenticationIdentity.Region = identity.Region;
                authenticationIdentity.IsShowInStock = identity.IsShowInStock;
                authenticationIdentity.Country = identity.Country;
                authenticationIdentity.CountryFullName = identity.CountryFullName;
                authenticationIdentity.ContinentId = identity.ContinentId;
                authenticationIdentity.ExclusivityGroupId = identity.ExclusivityGroupId;
                authenticationIdentity.RequestIpAddress = identity.RequestIpAddress;
                authenticationIdentity.ResponseIpAddress = identity.ResponseIpAddress;
            }
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = genericPrincipal;
            }
        }
    }
}