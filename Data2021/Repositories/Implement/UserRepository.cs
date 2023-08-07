
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;

namespace TA.Data2021.Repositories
{
    public class UserRepository : Repository<TA.Data2021.Models.User>, IUserRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public UserRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public TA.Data2021.Models.User GetByID(string ID)
        {
            TA.Data2021.Models.User result = new TA.Data2021.Models.User();
            if (!string.IsNullOrEmpty(ID))
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ID",ID),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_UserSelectUserDataTransferByID", parameters);
                List<TA.Data2021.Models.User> list = SQLHelper.ToList<TA.Data2021.Models.User>(dt);
                if (list.Count > 0)
                {
                    result = list[0];
                }
            }
            return result;
        }
    }
}

