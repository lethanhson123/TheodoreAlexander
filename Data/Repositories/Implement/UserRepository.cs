using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public UserRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public UserDataTransfer001 GetUserDataTransfer001ByID(string ID)
        {
            UserDataTransfer001 result = new UserDataTransfer001();
            if (string.IsNullOrEmpty(ID))
            {
            }
            else
            {
                try
                {
                    ID = ID.Trim();
                    SqlParameter[] parameters =
                       {
                        new SqlParameter("@ID",ID),
                       };
                    System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserSelectUserDataTransferByID", parameters);
                    List<UserDataTransfer001> list = SQLHelper.ToList<UserDataTransfer001>(dt);
                    if (list.Count > 0)
                    {
                        result = list[0];
                    }

                }
                catch (Exception e)
                {
                    string mes = e.Message;
                }
            }
            return result;
        }
        public List<UserDataTransfer> GetDataTransferByStoreIDToList(string storeID)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            if (string.IsNullOrEmpty(storeID))
            {
            }
            else
            {
                try
                {
                    storeID = storeID.Trim();
                    SqlParameter[] parameters =
                       {
                        new SqlParameter("@StoreID",storeID),
                       };
                    System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserSelectByStoreID", parameters);
                    result = SQLHelper.ToList<UserDataTransfer>(dt);
                }
                catch (Exception e)
                {
                    string mes = e.Message;
                }
            }
            return result;
        }
        public List<UserDataTransfer> GetDataTransferByRowNumberToList(int rowNumber)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            SqlParameter[] parameters =
               {
                        new SqlParameter("@RowNumber",rowNumber),
                       };
            System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserDataTransferSelectByRowNumber", parameters);
            result = SQLHelper.ToList<UserDataTransfer>(dt);
            return result;
        }
        public List<UserDataTransfer> GetUserEmailDataTransferQuotationByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            try
            {
                DateTime dateBegin = new DateTime(dateBeginYear, dateBeginMonth, dateBeginDay, 0, 0, 0);
                DateTime dateEnd = new DateTime(dateEndYear, dateEndMonth, dateEndDay, 23, 59, 59);
                SqlParameter[] parameters =
                {
                        new SqlParameter("@DateBegin",dateBegin),
                        new SqlParameter("@DateEnd",dateEnd),
                };
                System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserSelectEmailQuotationByDateBeginAndDateEnd", parameters);
                result = SQLHelper.ToList<UserDataTransfer>(dt);
            }
            catch
            {
            }
            return result;
        }
        public List<UserDataTransfer> GetUserEmailDataTransferRegisterByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            try
            {
                DateTime dateBegin = new DateTime(dateBeginYear, dateBeginMonth, dateBeginDay, 0, 0, 0);
                DateTime dateEnd = new DateTime(dateEndYear, dateEndMonth, dateEndDay, 23, 59, 59);
                SqlParameter[] parameters =
                {
                        new SqlParameter("@DateBegin",dateBegin),
                        new SqlParameter("@DateEnd",dateEnd),
                };
                System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserSelectEmailRegisterByDateBeginAndDateEnd", parameters);
                result = SQLHelper.ToList<UserDataTransfer>(dt);
            }
            catch
            {
            }
            return result;
        }
        public List<UserDataTransfer> GetUserEmailDataTransferSubcribedByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            try
            {
                DateTime dateBegin = new DateTime(dateBeginYear, dateBeginMonth, dateBeginDay, 0, 0, 0);
                DateTime dateEnd = new DateTime(dateEndYear, dateEndMonth, dateEndDay, 23, 59, 59);
                SqlParameter[] parameters =
                {
                        new SqlParameter("@DateBegin",dateBegin),
                        new SqlParameter("@DateEnd",dateEnd),
                };
                System.Data.DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionStringLIVE, "sp_UserSelectEmailSubcribedByDateBeginAndDateEnd", parameters);
                result = SQLHelper.ToList<UserDataTransfer>(dt);
            }
            catch
            {
            }
            return result;
        }
        public List<UserDataTransfer> GetUserEmailDataTransferByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay, bool isSubcribed, bool isRegister, bool isQuotation)
        {
            List<UserDataTransfer> result = new List<UserDataTransfer>();
            if (isQuotation == true)
            {
                result.AddRange(GetUserEmailDataTransferQuotationByDateBeginAndDateEndToList(dateBeginYear, dateBeginMonth, dateBeginDay, dateEndYear, dateEndMonth, dateEndDay));
            }
            if (isRegister == true)
            {
                result.AddRange(GetUserEmailDataTransferRegisterByDateBeginAndDateEndToList(dateBeginYear, dateBeginMonth, dateBeginDay, dateEndYear, dateEndMonth, dateEndDay));
            }
            if (isSubcribed == true)
            {
                result.AddRange(GetUserEmailDataTransferSubcribedByDateBeginAndDateEndToList(dateBeginYear, dateBeginMonth, dateBeginDay, dateEndYear, dateEndMonth, dateEndDay));
            }
            return result;
        }
    }
}

