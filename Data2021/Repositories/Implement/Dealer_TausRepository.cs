
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data2021.Models;
using TA.Helpers2021;
using TA.Data2021.Repositories;
using System.Threading.Tasks;

namespace TA.Data2021.Repositories
{
    public class Dealer_TausRepository : Repository<TA.Data2021.Models.Dealer_Taus>, IDealer_TausRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public Dealer_TausRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }

        public List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer> GetByUserIDToList(string userID)
        {
            List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer> result = new List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID",userID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Dealer_TausSelectItemsByUserID", parameters);
            result = SQLHelper.ToList<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>(dt);
            return result;
        }
        public async Task<List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>> AsyncGetByUserIDToList(string userID)
        {
            List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer> result = new List<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>();
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID",userID),
            };
            DataTable dt = await SQLHelper.FillAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_Dealer_TausSelectItemsByUserID", parameters);
            result = SQLHelper.ToList<TA.Data2021.DataTransfer.Dealer_TausDataTransfer>(dt);
            return result;
        }
    }
}

