using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TA.Data.DataTransfer;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly TheodoreAlexander_NewContext _context;
        public ShoppingCartRepository(TheodoreAlexander_NewContext context) : base(context)
        {
            _context = context;
        }
        public ShoppingCart GetByID(string ID)
        {
            ShoppingCart result = new ShoppingCart();
            if (!string.IsNullOrEmpty(ID))
            {
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
                if (result == null)
                {
                    result = new ShoppingCart();
                }
            }
            return result;
        }
        public override List<ShoppingCart> GetAllToList()
        {
            List<ShoppingCart> result = new List<ShoppingCart>();
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartSelectAllItems");
            result = SQLHelper.ToList<ShoppingCart>(dt);
            return result;
        }
        public List<ShoppingCart> GetBySearchStringToList(string searchString)
        {
            List<ShoppingCart> result = new List<ShoppingCart>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                {
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartSelectBySearchString", parameters);
                result = SQLHelper.ToList<ShoppingCart>(dt);
            }
            return result;
        }

        public async Task<int> AsyncUpdateBySQL(ShoppingCart model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
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
                new SqlParameter("@ContainerReference",model.ContainerReference),
                new SqlParameter("@SpecialInstruction",model.SpecialInstruction),                
            };
            string mes = await SQLHelper.ExecuteNonQueryAsync(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartUpdateSingleItemByID", parameters);
            return result;
        }
        public int UpdateBySQL(ShoppingCart model)
        {
            int result = AppGlobal.InitializationNumber;
            Initialization(model);
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
                new SqlParameter("@ContainerReference",model.ContainerReference),
                new SqlParameter("@SpecialInstruction",model.SpecialInstruction),
                new SqlParameter("@IsActive",model.IsActive),
            };
            string mes = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_ShoppingCartUpdateSingleItemByID", parameters);
            return result;
        }
    }
}

