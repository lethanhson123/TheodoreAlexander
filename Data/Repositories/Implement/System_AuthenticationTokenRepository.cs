using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class System_AuthenticationTokenRepository : RepositoryERP<System_AuthenticationToken>, ISystem_AuthenticationTokenRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public System_AuthenticationTokenRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public System_AuthenticationToken GetByAuthenticationToken(string authenticationToken)
        {
            System_AuthenticationToken result = new System_AuthenticationToken();
            if (!string.IsNullOrEmpty(authenticationToken))
            {
                SqlParameter[] parameters =
               {
                new SqlParameter("@AuthenticationToken", authenticationToken),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_ERPSQLServerConectionString, "sp_System_AuthenticationTokenSelectSingleItemByAuthenticationToken", parameters);
                List<System_AuthenticationToken> list = SQLHelper.ToList<System_AuthenticationToken>(dt);
                if (list.Count > 0)
                {
                    result = list[0];
                }
            }
            return result;
        }
    }
}

