using System.Collections.Generic;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface ISystem_MembershipRepository : IRepositoryERP<System_Membership>
    {
        public List<System_Membership> GetBySearchStringToList(string searchString);
        public System_Membership AuthenticationByEmailAndPasswordAndURL(string email, string password, string urlDestination);
    }
}

