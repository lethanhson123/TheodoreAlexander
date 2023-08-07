using System.Collections.Generic;
using TA.Data.DataTransfer;
using TA.Data.Models;
namespace TA.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public UserDataTransfer001 GetUserDataTransfer001ByID(string ID);
        public List<UserDataTransfer> GetDataTransferByStoreIDToList(string storeID);
        public List<UserDataTransfer> GetDataTransferByRowNumberToList(int rowNumber);
        public List<UserDataTransfer> GetUserEmailDataTransferByDateBeginAndDateEndToList(int dateBeginYear, int dateBeginMonth, int dateBeginDay, int dateEndYear, int dateEndMonth, int dateEndDay, bool isSubcribed, bool isRegister, bool isQuotation);        
    }
}

