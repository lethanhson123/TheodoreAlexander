using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data.Models;
using TA.Data.Repositories;
namespace TA.API.Controllers
{
    public class System_AuthenticationTokenController : BaseController
    {
        private readonly ISystem_AuthenticationTokenRepository _system_AuthenticationTokenRepository;
        public System_AuthenticationTokenController(ISystem_AuthenticationTokenRepository system_AuthenticationTokenRepository) : base()
        {
            _system_AuthenticationTokenRepository = system_AuthenticationTokenRepository;
        }
        [HttpGet]
        public System_AuthenticationToken GetByAuthenticationToken(string authenticationToken)
        {
            System_AuthenticationToken result = new System_AuthenticationToken();
            if (!string.IsNullOrEmpty(authenticationToken))
            {
                authenticationToken = authenticationToken.Split('=')[authenticationToken.Split('=').Length - 1];
                result = _system_AuthenticationTokenRepository.GetByAuthenticationToken(authenticationToken);
            }
            return result;
        }
    }
}

