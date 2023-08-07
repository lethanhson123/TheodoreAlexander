
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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShoppingCartRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public async Task<int> AsyncUpdateBySQL(ShoppingCart model)
        {
            int result = AppGlobal.InitializationNumber;
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@Code",model.Code),
                new SqlParameter("@OrderDate",model.OrderDate),
                new SqlParameter("@ItemCount",model.ItemCount),
                new SqlParameter("@Total",model.Total),
                new SqlParameter("@Volume",model.Volume),
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@StoreName",model.StoreName),
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@UserTypeName",model.UserTypeName),
                new SqlParameter("@ShippingDate",model.ShippingDate),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@BillingAddressString",model.BillingAddressString),
                new SqlParameter("@ShippingAddressString",model.ShippingAddressString),
                new SqlParameter("@StoreID",model.StoreID),
                new SqlParameter("@TausID",model.TausID),
                new SqlParameter("@ContainerReference",model.ContainerReference),
                new SqlParameter("@SpecialInstruction",model.SpecialInstruction),
                new SqlParameter("@IsActive",model.IsActive),
                };
            string mes = await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartUpdateSingleItemByID", parameters);
            return result;
        }
        public string UpdateBySQL(ShoppingCart model)
        {
            string mes = AppGlobal.InitializationString;
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@ID",model.ID.Value.ToString()),
                new SqlParameter("@Code",model.Code),
                new SqlParameter("@OrderDate",model.OrderDate),
                new SqlParameter("@ItemCount",model.ItemCount),
                new SqlParameter("@Total",model.Total),
                new SqlParameter("@Volume",model.Volume),
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@StoreName",model.StoreName),
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@UserTypeName",model.UserTypeName),
                new SqlParameter("@ShippingDate",model.ShippingDate),
                new SqlParameter("@Email",model.Email),
                new SqlParameter("@BillingAddressString",model.BillingAddressString),
                new SqlParameter("@ShippingAddressString",model.ShippingAddressString),
                new SqlParameter("@StoreID",model.StoreID),
                new SqlParameter("@TausID",model.TausID),
                new SqlParameter("@ContainerReference",model.ContainerReference),
                new SqlParameter("@SpecialInstruction",model.SpecialInstruction),
                new SqlParameter("@IsActive",model.IsActive),
                };
                mes = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartUpdateSingleItemByID", parameters);
            }
            catch (Exception e)
            {
                mes = e.Message;
            }
            mes = "UpdateBySQL: " + mes;
            return mes;
        }
        public ShoppingCart GetByID(string ID)
        {
            ShoppingCart result = new ShoppingCart();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ID",ID),
                };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartSelectByID", parameters);
            List<ShoppingCart> list = SQLHelper.ToList<ShoppingCart>(dt);
            if (list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }
    }
}

