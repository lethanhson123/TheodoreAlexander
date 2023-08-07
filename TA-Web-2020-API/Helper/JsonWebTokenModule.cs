using BL;
using DAL.ViewModels;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TA_Web_2020_API.Helper
{
    public class JsonWebTokenModule
    {
        private static readonly string communicationKey = ConfigurationManager.AppSettings["SecretKey"];
        private static readonly int expireDay = 3;
        public async Task<string> GenerateToken(Guid userId, HttpRequestMessage Request)
        {
            //Get Ip Address
            string requestIpAddress = Helper.GetClientIp(Request);
            string responseIpAddress = string.Empty;
            string IpAddress = string.Empty;
            //try to get ipaddress from header (fake ip for testing)
            var checkIpAddressExists = Request.Headers.TryGetValues("Ip_Address", out IEnumerable<string> lsHeaders);
            if (checkIpAddressExists)
            {
                IpAddress = lsHeaders.FirstOrDefault();
                responseIpAddress = IpAddress;
            }
            else {
                //try to get ip address from request (real ip of user)
                IpAddress = Helper.GetClientIp(Request);
                responseIpAddress = IpAddress;
            }
            if (String.IsNullOrEmpty(IpAddress))
            {
                //if cannot get Ip address, set the default ipaddress as highpoint US
                IpAddress = ConfigurationManager.AppSettings["DefaultIp"]; //Default Ip Address
                responseIpAddress = IpAddress;
            }


            //Get services
            var _generalServices = Request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(BL.BusinessService.GeneralBusinessService)) as BL.BusinessService.GeneralBusinessService;
            var _userServices = Request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(BL.BusinessService.UserBusinessService)) as BL.BusinessService.UserBusinessService;
            UserViewModel user = await _userServices.GetUserById(userId);
            //Get Country Id
            var countryId = await _generalServices.GetCountryId(IpAddress);
            //Get User region
            var userRegion = _userServices.GetUserRegion(countryId, user != null ? user.ID : Guid.Empty, user != null ? user.UserTypeName : LocalUserType.Anonymous);
            //Get Maxmind location
            var maxMind = _generalServices.GetLocationMaxMind(countryId);
            //check is north america
            var isShowInStock = _generalServices.IsShowInStock(maxMind.Country);
            //Get ExclusivityGroup
            var exclusivityGroupId = new Guid();
            if ((user != null ? user.UserTypeName : LocalUserType.Anonymous) == LocalUserType.Dealer || (user != null ? user.UserTypeName : LocalUserType.Anonymous) == LocalUserType.SalesAssociate)
            {
                exclusivityGroupId = _userServices.GetDealerExclusivityGroup_ID_ByUserId(user.ID);
            }

            var signingKey = Convert.FromBase64String(communicationKey);
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim("UserId", (user != null ? user.ID:Guid.Empty).ToString()),
                new Claim("UserName", user != null ? user.Username : String.Empty),
                new Claim("Email", user != null ? user.Email : String.Empty),
                new Claim("FirstName", user != null ? user.Firstname : String.Empty),
                new Claim("LastName", user != null ? user.Lastname : String.Empty),
                new Claim("UserType", user != null ? user.UserTypeName : LocalUserType.Anonymous),
                new Claim("CountryId", countryId.ToString()),
                new Claim("Region", userRegion.ToString()),
                new Claim("Country", maxMind.Country),
                new Claim("CountryFullName", maxMind.CountryFullName),
                new Claim("IsShowInStock", isShowInStock.ToString()),
                new Claim("ContinentId", maxMind.ContinentId.ToString()),
                new Claim("ExclusivityGroupId", exclusivityGroupId.ToString()),
                new Claim("RequestIpAddress", requestIpAddress),
                new Claim("ResponseIpAddress", responseIpAddress)
            }, "Custom");
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = now.AddDays(expireDay),
                SigningCredentials = signingCredentials,
                Audience = ConfigurationManager.AppSettings["Audiences"],
                Issuer = "self"
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }
        public string GenerateRefreshToken(List<Claim> claims)
        {
            var signingKey = Convert.FromBase64String(communicationKey);
            var now = DateTime.UtcNow;
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
               SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
            var subject = new ClaimsIdentity(claims);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = now.AddDays(expireDay),
                SigningCredentials = signingCredentials,
                Audience = ConfigurationManager.AppSettings["Audiences"],
                Issuer = "self"
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }
        public ClaimsPrincipal ValidateExpiredToken(string token)
        {
            try
            {
                IdentityModelEventSource.ShowPII = true;
                var tokenHandler = new JwtSecurityTokenHandler();
                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
                    return null;
                var signingKey = Convert.FromBase64String(communicationKey);
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidAudiences = new string[]
                      {
                        ConfigurationManager.AppSettings["Audiences"],
                      },

                    ValidIssuers = new string[]
                      {
                          "self",
                      },
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
                    return null;
                var signingKey = Convert.FromBase64String(communicationKey);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudiences = new string[]
                      {
                        ConfigurationManager.AppSettings["Audiences"],
                      },

                    ValidIssuers = new string[]
                      {
                          "self",
                      },
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }
            catch
            {
                return null;
            }
        }
        public JWTAuthenIdentity GenerateIdentity(ClaimsPrincipal principal)
        {
            if(principal == null)
            {
                return null;
            }
            if (!(principal.Identity is ClaimsIdentity identity))
            {
                return null;
            }
            string UserId = identity.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).FirstOrDefault();
            string UserName = identity.Claims.Where(c => c.Type == "UserName").Select(c => c.Value).FirstOrDefault();
            string Email = identity.Claims.Where(c => c.Type == "Email").Select(c => c.Value).FirstOrDefault();
            string FirstName = identity.Claims.Where(c => c.Type == "FirstName").Select(c => c.Value).FirstOrDefault();
            string LastName = identity.Claims.Where(c => c.Type == "LastName").Select(c => c.Value).FirstOrDefault();
            string CountryId = identity.Claims.Where(c => c.Type == "CountryId").Select(c => c.Value).FirstOrDefault();
            string UserType = identity.Claims.Where(c => c.Type == "UserType").Select(c => c.Value).FirstOrDefault();
            string Region = identity.Claims.Where(c => c.Type == "Region").Select(c => c.Value).FirstOrDefault();
            string Country = identity.Claims.Where(c => c.Type == "Country").Select(c => c.Value).FirstOrDefault();
            string CountryFullName = identity.Claims.Where(c => c.Type == "CountryFullName").Select(c => c.Value).FirstOrDefault();
            string ContinentId = identity.Claims.Where(c => c.Type == "ContinentId").Select(c => c.Value).FirstOrDefault();
            string IsShowInStock = identity.Claims.Where(c => c.Type == "IsShowInStock").Select(c => c.Value).FirstOrDefault();
            string ExclusivityGroupId = identity.Claims.Where(c => c.Type == "ExclusivityGroupId").Select(c => c.Value).FirstOrDefault();
            string RequestIpAddress = identity.Claims.Where(c => c.Type == "RequestIpAddress").Select(c => c.Value).FirstOrDefault();
            string ResponseIpAddress = identity.Claims.Where(c => c.Type == "ResponseIpAddress").Select(c => c.Value).FirstOrDefault();
            return new JWTAuthenIdentity(UserId)
            {
                UserId = UserId,
                UserName = UserName,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                CountryId = CountryId,
                UserType = UserType,
                Region = Region,
                Country = Country,
                CountryFullName = CountryFullName,
                IsShowInStock = bool.Parse(IsShowInStock),
                ContinentId = ContinentId,
                ExclusivityGroupId = ExclusivityGroupId,
                RequestIpAddress = RequestIpAddress,
                ResponseIpAddress = ResponseIpAddress
            };
        }
        public async Task<JWTAuthenIdentity> GenerateDefaultIdentity(HttpRequestMessage Request)
        {
            var IpAddress = ConfigurationManager.AppSettings["DefaultIp"];
            //Get service
            var _generalServices = Request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(BL.BusinessService.GeneralBusinessService)) as BL.BusinessService.GeneralBusinessService;
            var _userServices = Request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(BL.BusinessService.UserBusinessService)) as BL.BusinessService.UserBusinessService;
            //Get Country Id
            var countryId = await _generalServices.GetCountryId(IpAddress);
            //Get User region
            var user = new JWTIdentityViewModel();
            var userRegion = _userServices.GetUserRegion(countryId, user.UserId.Value, user.UserType);
            //Get Maxmind location
            var maxMind = _generalServices.GetLocationMaxMind(countryId);
            //check is north america
            var isShowInStock = _generalServices.IsShowInStock(maxMind.Country);

            return new JWTAuthenIdentity("")
            {
                UserId = "",
                Email = "",
                UserName = "",
                CountryId = countryId.ToString(),
                UserType = "Consumer",
                Region = userRegion,
                Country = maxMind.Country,
                CountryFullName = maxMind.CountryFullName,
                IsShowInStock = isShowInStock,
                ContinentId = maxMind.ContinentId.ToString(),
                ExclusivityGroupId = new Guid().ToString(),
                RequestIpAddress = IpAddress,
                ResponseIpAddress = IpAddress
            };
        }
    }
    public class JWTAuthenIdentity : GenericIdentity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string CountryId { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CountryFullName { get; set; }
        public bool IsShowInStock { get; set; }
        public string ContinentId { get; set; }
        public string ExclusivityGroupId { get; set; }
        public string RequestIpAddress { get; set; }
        public string ResponseIpAddress { get; set; }
        public JWTAuthenIdentity(string userName) : base(userName)
        {
            UserId = userName;
        }

        public static bool IsDirtyIdentity (JWTAuthenIdentity oldIdentity, JWTAuthenIdentity newIdentity)
        {
            bool isDirty = false;

            isDirty = isDirty || oldIdentity.UserId != newIdentity.UserId;
            isDirty = isDirty || oldIdentity.UserName != newIdentity.UserName;
            isDirty = isDirty || oldIdentity.Email != newIdentity.Email;
            isDirty = isDirty || oldIdentity.FirstName != newIdentity.FirstName;
            isDirty = isDirty || oldIdentity.LastName != newIdentity.LastName;
            isDirty = isDirty || oldIdentity.UserType != newIdentity.UserType;
            isDirty = isDirty || oldIdentity.CountryId != newIdentity.CountryId;
            isDirty = isDirty || oldIdentity.Region != newIdentity.Region;
            isDirty = isDirty || oldIdentity.Country != newIdentity.Country;
            isDirty = isDirty || oldIdentity.CountryFullName != newIdentity.CountryFullName;
            isDirty = isDirty || oldIdentity.IsShowInStock != newIdentity.IsShowInStock;
            isDirty = isDirty || oldIdentity.ContinentId != newIdentity.ContinentId;
            isDirty = isDirty || oldIdentity.ExclusivityGroupId != newIdentity.ExclusivityGroupId;
            isDirty = isDirty || oldIdentity.RequestIpAddress != newIdentity.RequestIpAddress;
            isDirty = isDirty || oldIdentity.ResponseIpAddress != newIdentity.ResponseIpAddress;

            return isDirty;
        }
    }
}