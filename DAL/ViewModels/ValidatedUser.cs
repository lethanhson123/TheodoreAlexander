using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ValidatedUser
    {
        public Guid ID { get; set; }
        public bool EmailVerified { get; set; }
        public bool AccountEnabled { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AccountNumber { get; set; }
        public UserTypeViewModel UserTypeViewModel { get; set; }
        public string Region { get; set; }
        public ValidatedUser()
        {
            ID = new Guid();
            UserTypeViewModel = new UserTypeViewModel() {
                Name = LocalUserType.Anonymous
            };
        }
    }
    public class UserTypeViewModel {
        public string Name { get; set; }
    }

    public class UserAddToRespHeader
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string Region { get; set; }
        public string RequestIpAddress { get; set; }
        public string ResponseIpAddress { get; set; }
        public UserAddToRespHeader()
        {
            ID = new Guid();
        }
    }
    //public class UserInfoForCreateJwt
    //{
    //    public Guid ID { get; set; }
    //    public string UserType { get; set; }
    //    public string UserName { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public UserInfoForCreateJwt()
    //    {
    //        ID = new Guid();
    //    }
    //}
    public class LocalUserType{
        public const string Anonymous = "Anonymous";
        public const string Consumer = "Consumer";
        public const string Designer = "Designer";
        public const string SalesAssociate = "Sales Associate";
        public const string Dealer = "Dealer";
        public const string ProspectiveTradeAccount = "ProspectiveTradeAccount";
    }
    public class LocalUserTypeId
    {
        public const string Consumer = "AF56EF11-0A9E-461D-A0DC-4534CFA15EB6";
        public const string Designer = "6B21FDF3-1C39-48E2-8F25-9FACE271E409";
        public const string SalesAssociate = "2DA9A595-C959-48B3-AA01-C7CA5B72B665";
        public const string Dealer = "FC96242C-9D5D-4E54-BCC1-45F0B65D2CA8";
        public const string ProspectiveTradeAccount = "BDE4B914-849E-4B80-A83D-74B8EF8C09D8";
    }
}
