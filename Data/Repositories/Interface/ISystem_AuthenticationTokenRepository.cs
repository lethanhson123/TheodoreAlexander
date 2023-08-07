using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISystem_AuthenticationTokenRepository : IRepositoryERP<System_AuthenticationToken>
    {
        public System_AuthenticationToken GetByAuthenticationToken(string authenticationToken);
    }
}

