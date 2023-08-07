using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BL.EntityService;
using DAL;
using DAL.ViewModels;
using BL.CustomExceptions;
using System.Transactions;
using System.Configuration;
using TA_Web_2020_API.Helper;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class UserBusinessService
    {
        private readonly SalesAssociate_StoreEntityService _sasStoreServices;
        private readonly DealerEntityService _dealerServices;
        private readonly ExclusivityGroupEntityService _excServices;
        private readonly CountryEntityService _countryServices;
        private readonly DealerGroup_RegionEntityService _dealerGroupRegionServices;
        private readonly UserModelServices _userServices;
        private readonly DAL.EntityService.DataContextServices _dataServices;
        private readonly StoreEntityService _storeServices;
        private readonly WishListModelServices _wishListModelServices;
        private readonly AddressEntityService _addressModelServices;
        protected string _noReplyEmail = ConfigurationManager.AppSettings["SMTPno-reply"];
        protected string _emailTAsales = ConfigurationManager.AppSettings["EmailTAsales"];
        private bool disposed = false;

        public UserBusinessService(SalesAssociate_StoreEntityService sasStoreServices,
            DealerEntityService dealerServices,
            ExclusivityGroupEntityService excServices,
            CountryEntityService countryServices,
            DealerGroup_RegionEntityService dealerGroupRegionServices,
            UserModelServices userServices,
            DAL.EntityService.DataContextServices dataServices,
            StoreEntityService storeServices,
            WishListModelServices wishListModelServices,
            AddressEntityService addressModelServices)
        {
            _sasStoreServices = sasStoreServices;
            _dealerServices = dealerServices;
            _excServices = excServices;
            _countryServices = countryServices;
            _dealerGroupRegionServices = dealerGroupRegionServices;
            _userServices = userServices;
            _dataServices = dataServices;
            _storeServices = storeServices;
            _wishListModelServices = wishListModelServices;
            _addressModelServices = addressModelServices;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _sasStoreServices.Dispose();
                _dealerServices.Dispose();
                _excServices.Dispose();
                _countryServices.Dispose();
                _dealerGroupRegionServices.Dispose();
                _userServices.Dispose();
                _dataServices.Dispose();
                _wishListModelServices.Dispose();
                _addressModelServices.Dispose();
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Guid GetDealerExclusivityGroup_ID_ByUserId(Guid? Id)
        {
            try
            {
                var dealer = _dealerServices.GetDealerByUserId(Id);
                if (dealer != null && dealer.ExclusivityGroup_ID.HasValue)
                {
                    return dealer.ExclusivityGroup_ID.Value;
                }
                var sas = _sasStoreServices.GetSalesAssociate_StoresByUserId(Id);
                if (sas != null)
                {
                    var dealerStore = sas.Store.Dealers.FirstOrDefault();
                    if (dealerStore != null)
                    {
                        if (dealerStore.ExclusivityGroup_ID != null)
                        {
                            return dealerStore.ExclusivityGroup_ID.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Guid();
        }

        public string GetUserRegion(Guid? countryId, Guid userId, string userType)
        {
            try
            {
                //get region by IP Address
                string region = "taus";
                var country = _countryServices.GetCountryById(countryId);
                if (country != null && country.ISO != "US" && country.ISO != "CA" && country.ISO != "MX")
                {
                    region = "international";
                }

                //If Dealer or SA, get region from the system
                if (userType == LocalUserType.Dealer || userType == LocalUserType.SalesAssociate)
                {
                    Guid exclusivityGroupId = GetDealerExclusivityGroup_ID_ByUserId(userId);
                    var excGroup = _excServices.GetExclusivityGroupsById(exclusivityGroupId);
                    if (excGroup != null)
                    {
                        var dealerGroupRegion = _dealerGroupRegionServices.GetDealerGroup_Region(excGroup.Name);
                        if (dealerGroupRegion == null)
                        {
                            region = "international";
                        }
                        else {
                            region = dealerGroupRegion.region;
                        }
                    }
                }
                return region;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ValidatedUser> Login(LoginModel model, string IpAddress)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = new User
                    {
                        Username = model.UserName,
                        Password = model.Password
                    };
                    var loginUser = await _userServices.GetUserByLoginNameAndPassword(user);
                    ValidatedUser validatedUser = null;
                    if (loginUser != null)
                    {
                        //if (!loginUser.EmailVerified)
                        //{
                        //    scope.Dispose();
                        //    throw new BadRequestException("EmailNotVerified");
                        //}
                        //if (!loginUser.AccountEnabled)
                        //{
                        //    scope.Dispose();
                        //    throw new BadRequestException("AccountDisabled");
                        //}
                        validatedUser = new ValidatedUser
                        {
                            ID = loginUser.ID,
                            EmailVerified = loginUser.EmailVerified,
                            AccountEnabled = loginUser.AccountEnabled,
                            Username = loginUser.Username,
                            Firstname = loginUser.Firstname,
                            Lastname = loginUser.Lastname,
                            Email = loginUser.Email,
                            AccountNumber = loginUser.AccountNumber,
                            UserTypeViewModel = new UserTypeViewModel
                            {
                                Name = loginUser.UserType.Name.Replace(" ", String.Empty)
                            }
                        };
                        //Get Country Id
                        var countryId = await _dataServices.GetCountryId(IpAddress);
                        //Get User region
                        JWTIdentityViewModel jwtUser = new JWTIdentityViewModel
                        {
                            UserId = validatedUser.ID,
                            UserType = validatedUser.UserTypeViewModel.Name,
                            AccountNumber = validatedUser.AccountNumber,
                            UserName = validatedUser.Username,
                            FirstName = validatedUser.Firstname,
                            LastName = validatedUser.Lastname,
                            Email = validatedUser.Email
                        };
                        var userRegion = GetUserRegion(countryId, validatedUser.ID, validatedUser.UserTypeViewModel.Name);
                        validatedUser.Region = userRegion;

                    }
                    scope.Complete();
                    return validatedUser;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<UserTypeForRegisterUserViewModel> GetUserTypesForRegisterUser()
        {
            try
            {
                var lstUserType = await _userServices.GetAllUserType().ToListAsync();
                List<UserTypeSelectOption> userTypeSelectOption = new List<UserTypeSelectOption>();
                userTypeSelectOption = lstUserType.Select(o => new UserTypeSelectOption
                {
                    ID = o.ID,
                    Name = o.Name
                }).ToList();
                // Purchase
                OptionUserTypeForRegisterUserViewModel purchase = new OptionUserTypeForRegisterUserViewModel
                {
                    Name = "Purchase view",
                    UserTypes = userTypeSelectOption.Where(o => o.Name.Equals("Dealer") || o.Name.Equals("Sales Associate")).ToList()
                };
                // Browse
                OptionUserTypeForRegisterUserViewModel browse = new OptionUserTypeForRegisterUserViewModel
                {
                    Name = "Browse view",
                    UserTypes = userTypeSelectOption.Where(o => (o.Name.Equals("Consumer") || o.Name.Equals("Designer")) && !o.Name.Equals("Prospective Trade Account")).ToList()
                };
                if (browse.UserTypes.Count > 0)
                {
                    browse.UserTypes.Add(new UserTypeSelectOption { ID = new Guid(), Name = "Other" });
                }
                UserTypeForRegisterUserViewModel userTypeForRegisterUserViewModel = new UserTypeForRegisterUserViewModel();
                userTypeForRegisterUserViewModel.UserTypeGroups.Add(purchase);
                userTypeForRegisterUserViewModel.UserTypeGroups.Add(browse);
                return userTypeForRegisterUserViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> AddUser(UserViewModel userViewModel, Guid userTypeId)
        {
            try
            {
                User user = new User
                {
                    ID = Guid.NewGuid(),
                    UserType_ID = userTypeId,
                    Username = userViewModel.Username,
                    Firstname = userViewModel.Firstname,
                    Lastname = userViewModel.Lastname,
                    Password = Helper.EncryptPassword(userViewModel.Password),
                    Email = userViewModel.Email,
                    EmailVerified = false,
                    AccountEnabled = true,
                    DateCreated = DateTime.UtcNow,
                    Address1 = userViewModel.Address1,
                    Provider = userViewModel.Provider                    
                };
                var addUser = await _userServices.AddUser(user);
                if (addUser)
                {
                    return user.ID;
                }
                else
                {
                    return Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                return Guid.Empty;
            }
        }

        public async Task<Guid> RegisterUser(RegisterUserObj registerUserObj, string IpAddress, bool isRequiredVerifyEmail)
        {
            // Step: 
            // 1: Insert User to DB, insert anonymous wishlist if needed
            // 2: Send email for TA sales if user is dealer or designer

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // Step 1:
                    UserViewModel user = new UserViewModel
                    {
                        Username = registerUserObj.Email,
                        Password = registerUserObj.Password,
                        Email = registerUserObj.Email,
                        Firstname = registerUserObj.Firstname,
                        Lastname = registerUserObj.Lastname,
                        Address1 = registerUserObj.Address1,
                        Provider = registerUserObj.Provider
                    };
                    Guid userTypeId = new Guid(LocalUserTypeId.Consumer);
                    Guid? addedUserId = await AddUser(user, userTypeId);
                    if (!addedUserId.HasValue || addedUserId == Guid.Empty)
                    {
                        scope.Dispose();
                        return Guid.Empty;
                    }

                    StringBuilder sb;
                    string body;
                    if (isRequiredVerifyEmail)
                    {
                        // Step 2
                        // Build email and send
                        sb = new StringBuilder("This is to confirm your registration details at theodorealexander.com.<br/><br/>");
                        sb.Append("Registration information:<br/><br/><table style='font-size:12px' width='100%'>");
                        sb.Append("<tr><td width='35%'><b>Username</b> </td><td>").Append(registerUserObj.Username).Append("<br/><br/></td></tr>");
                        Helper.AppendAttr(sb, "Email address", registerUserObj.Email);
                        sb.Append("</table>");
                        sb.Append("<br /><br />Please <a href=\"" + ConfigurationManager.AppSettings["WebURL"] + "/verify-email/" + addedUserId + "\">click here</a> to verify your email address.<br/><br/>");
                        sb.Append("Please remember to always keep any personal information including account sign in details in a safe and secure location.<br/>");
                        sb.Append("If any information above is incorrect, please contact us at info@theodorealexander.com.");
                        if (registerUserObj.UserType_ID.ToString().ToUpper().Equals(LocalUserTypeId.SalesAssociate.ToUpper()))
                            sb.Append("<br/><br/>After confirming your email address you can register as a Sales Associate. Simply go to your Account Settings where you can request Sales Associate status.");
                        body = await Helper.RenderGenericEmail(sb.ToString());
                        bool sendConfirmEmail = await Helper.SendMail("Theodore Alexander", _noReplyEmail, registerUserObj.Username, registerUserObj.Email, "Confirming your Registration details", body);
                    }

                    if (registerUserObj.IsEmailSubscribed)
                    {
                        //Move from Verfi email
                        //add to email subscriber
                        Guid? countryId = await _dataServices.GetCountryId(IpAddress);
                        //Helper.AddNewUserMember(registerUserObj.Email, GetUserRegion(countryId, Guid.Empty, LocalUserType.Consumer));
                        new TAEmailMarketer().AddNewUserMember(registerUserObj.Email, GetUserRegion(countryId, Guid.Empty, LocalUserType.Consumer));
                    }

                    //Build and send Prospective Trade Account info to TA
                    bool sendTAsalesDealerInfo = false, sendTAsalesDesignerInfo = false;
                    if (registerUserObj.UserType_ID.ToString().ToUpper().Equals(LocalUserTypeId.Dealer.ToUpper()))
                    {
                        sb = new StringBuilder("A new Prospective Dealer has registered on the website.<br/><br/>");
                        sb.Append("Please qualify this account:<br/><br/>");
                        sb.Append("<b>Username: </b>" + registerUserObj.Username + "<br/>");
                        sb.Append("<b>Email:</b> " + registerUserObj.Email + "<br/>");
                        body = await Helper.RenderGenericEmail(sb.ToString());
                        sendTAsalesDealerInfo = await Helper.SendMail("Theodore Alexander", _noReplyEmail, _emailTAsales, _emailTAsales, "New Prospective Dealer", body);
                        if (!sendTAsalesDealerInfo)
                        {
                            scope.Dispose();
                        }
                    }
                    else if (registerUserObj.UserType_ID.ToString().ToUpper().Equals(LocalUserTypeId.Designer.ToUpper()))
                    {
                        sb = new StringBuilder("A new Prospective Designer has registered on the website.<br/><br/>");
                        sb.Append("Please qualify this account:<br/><br/>");
                        sb.Append("<b>Username: </b>" + registerUserObj.Username + "<br/>");
                        sb.Append("<b>Email:</b> " + registerUserObj.Email + "<br/>");
                        body = await Helper.RenderGenericEmail(sb.ToString());
                        sendTAsalesDesignerInfo = await Helper.SendMail("Theodore Alexander", _noReplyEmail, _emailTAsales, _emailTAsales, "New Prospective Designer", body);
                        if (!sendTAsalesDesignerInfo)
                        {
                            scope.Dispose();
                        }
                    }
                    
                    scope.Complete();
                    return addedUserId.Value;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<Guid?> CheckEmailExists(string email)
        {
            try
            {
                var user = await _userServices.GetUserEmails(email).FirstOrDefaultAsync();
                if (user != null)
                {
                    return user.ID;
                }
                else {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<string> ValidateRegisterUser(RegisterUserObj registerUserObj) {
            string errorMessage = String.Empty;

            var checkUsername = await this.CheckUsernameExists(registerUserObj.Username);
            var checkEmail = await this.CheckEmailExists(registerUserObj.Email);
            if (checkUsername) {
                errorMessage = "This username has been registered. Please use another one";
            }
            if (checkEmail != null) {
                errorMessage = "This email has been registered. Please use another one";
            }

            return errorMessage;
        }

        public async Task<bool> CheckUsernameExists(string userName)
        {
            try
            {
                bool result = false;
                var userNames = await _userServices.GetUserNames(userName).CountAsync();
                if (userNames > 0)
                {
                    result = true;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserViewModel> GetUserById(Guid? Id)
        {
            try
            {
                UserViewModel userViewModel = await _userServices.GetUsers_Queryable().Where(o => o.ID == Id).Select(u => new UserViewModel
                {
                    ID = u.ID,
                    Username = u.Username,
                    UserType_ID = u.UserType_ID,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    UserTypeName = u.UserType != null ? u.UserType.Name : string.Empty
                }).FirstOrDefaultAsync();
                return userViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserViewModel> EnabledEmail(Guid? userId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = true;
                    var user = await _userServices.GetUsers_Queryable().Where(o => o.ID == userId).FirstOrDefaultAsync();
                    if (user == null)
                    {
                        scope.Dispose();
                        return null;
                    }
                    if (!user.EmailVerified)
                    {
                        user.EmailVerified = true;
                        result = _userServices.UpdateUser(user);
                    }
                    if (!result)
                    {
                        scope.Dispose();
                        throw new BadRequestException(ConstClass.ConstException.BadRequestMess);
                    }
                    UserViewModel userViewModel = new UserViewModel
                    {
                        ID = user.ID,
                        Username = user.Username,
                        UserType_ID = user.UserType_ID,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        UserTypeName = user.UserType != null ? user.UserType.Name : string.Empty
                    };
                    scope.Complete();
                    return userViewModel;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<User> GetUserInfoByEmail(string email)
        {
            try
            {
                var users = await _userServices.GetUserEmails(email).ToListAsync();
                if (users.Count != 1)
                {
                    return null;
                }
                else
                {
                    var user = users.Single();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RetrieveUsername(string email)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = false;
                    var user = await GetUserInfoByEmail(email);
                    if (user == null)
                    {
                        scope.Complete();
                        return result;
                    }
                    string username = user.Username;
                    string fromName = "Theodore Alexander";
                    string fromEmail = _noReplyEmail;
                    string toEmail = email;
                    string emailSubject = "Your TheodoreAlexander.com username has been retrieved";
                    string emailBody = await Helper.RenderGenericEmail("As requested, we have successfully retrieved your username/email.<br /><br /><b>Your username is shown below:</b><br /><br />Username/email: " + username +
                        "<br/><br/>Please remember to always keep any personal information including account sign in details in a safe and secure location.");
                    result = await Helper.SendMail(fromName, fromEmail, user.Username, email, emailSubject, emailBody);
                    if (!result)
                    {
                        scope.Complete();
                        return result;
                    }
                    result = true;
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<bool> RetrieveEmail(string email)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = false;
                    var user = await GetUserInfoByEmail(email);
                    if (user == null)
                    {
                        scope.Complete();
                        return result;
                    }
                    string newPass = Helper.RandomString(8, false);
                    string hPass = Helper.EncryptPassword(newPass);
                    user.Password = hPass;
                    var edited = _userServices.UpdateUser(user);
                    if (!edited)
                    {
                        scope.Dispose();
                        return result;
                    }
                    string fromName = "Theodore Alexander";
                    string fromEmail = _noReplyEmail;
                    string username = email;
                    string password = newPass;
                    string subject = "Your TheodoreAlexander.com password has been retrieved";
                    string body = await Helper.RenderGenericEmail("As requested, we have successfully reset your password.<br /><br /><b>Your new password information is shown below:</b><br /><br />Username/Email: " + user.Username + "<br />Password: " + password + "<br/><br/>Please remember to always keep any personal information including account sign in details in a safe and secure location.");
                    result = await Helper.SendMail(fromName, fromEmail, user.Username, email, subject, body);
                    if (!result)
                    {
                        scope.Dispose();
                        return result;
                    }
                    result = true;
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<UserViewModel> GetUserInfo(Guid UserId)
        {
            try
            {
                var user = _userServices.GetAccountDataByUserID(UserId).FirstOrDefault();
                if (user != null)
                {
                    var CurrentUserType = await _userServices.GetAllUserType().Where(o => o.ID == user.ID).FirstOrDefaultAsync();
                    //var city = await _cityServices.GetCities().Where(o => o.Name == user.CityName).FirstOrDefaultAsync();
                    //var region = await _regionServices.GetRegions().Where(o => o.Name == user.RegionName).FirstOrDefaultAsync();
                    //var country = await _countryServices.GetCountries().Where(o => o.Name == user.CountryName).FirstOrDefaultAsync();
                    UserViewModel userView = new UserViewModel
                    {
                        ID = UserId,
                        AccountNumber = user.AccountNumber,
                        Username = user.Username,
                        Firstname = user.Firstname,
                        Lastname = user.Lastname,
                        Email = user.Email,
                        Address1 = user.Address1,
                        Address2 = user.Address2,
                        PostalCode = user.PostalCode,
                        CityName = user.CityName,
                        RegionName = user.RegionName,
                        CountryName = user.CountryName,
                        Password = string.Empty,
                        MailingAddress = string.Empty,
                        UserTypeName = CurrentUserType.Name,
                        City_ID = user.CityId,
                        Region_ID = user.RegionId,
                        Country_ID = user.CountryId
                    };
                    if (!String.IsNullOrEmpty(user.Address1) && !String.IsNullOrEmpty(user.Address2))
                    {
                        userView.MailingAddress = user.Address1 + "<br />" + user.Address2 + "<br />";
                    }
                    if (!String.IsNullOrEmpty(user.CityName) && !String.IsNullOrEmpty(user.RegionName))
                    {
                        userView.MailingAddress += user.CityName + ", " + user.RegionName + " " + user.PostalCode + "<br />" + user.CountryName;
                    }
                    var store = await _dealerServices.GetDealerByUserId_Queryable(UserId).Select(o => o.Stores.FirstOrDefault()).FirstOrDefaultAsync();
                    if (store != null)
                    {
                        userView.StoreInfo = new StoreViewModel
                        {
                            ID = store.ID,
                            Name = store.Name,
                            Phone = store.Phone,
                            Email = store.Email,
                            Website = store.Website,
                            PostalCode = store.PostalCode,
                            DateModified = store.DateModified,
                            Address1 = store.Address1,
                            Address2 = store.Address2,
                            CityName = store.City.Name,
                            RegionName = store.City.Region.Name,
                            CountryName = store.City.Region.Country.Name
                        };
                    }
                    return userView;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(UserModelModified userView)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = true;
                try
                {
                    Guid userId = (Guid)Helper.TryParseStringToGuid(userView.ID);
                    // check email exists
                    var user = await _userServices.GetUsers_Queryable().Where(o => o.ID == userId).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        if (!userView.Email.Equals(user.Email))
                        {
                            var checkEmailExists = await CheckEmailExists(userView.Email);
                            if (checkEmailExists != null)
                            {
                                throw new Exception("The email has been registered");
                            }
                            else
                            {
                                user.Email = userView.Email;
                            }
                        }
                        user.Firstname = userView.Firstname;
                        user.Lastname = userView.Lastname;
                        user.AccountNumber = userView.AccountNumber;

                        if (!String.IsNullOrEmpty(userView.CityId) && Helper.TryParseStringToGuid(userView.CityId) != Guid.Empty)
                        {
                            user.City_ID = (Guid)Helper.TryParseStringToGuid(userView.CityId);
                            user.Address1 = userView.Address1;
                            user.Address2 = userView.Address2;
                            user.PostalCode = userView.PostalCode;
                        }
                        result = _userServices.UpdateUser(user);
                    }
                    else
                    {
                        throw new Exception("Invalid user. Please re-login and try again");
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
                return result;
            }
        }

        public bool ChangePassword(PasswordModifiedModel modifiedModel, Guid userId, out string errorMessage)
        {
            var result = true;
            errorMessage = String.Empty;
            try
            {
                var user = _userServices.GetUsers_Queryable().Where(o => o.ID == userId).FirstOrDefault();
                if (user != null)
                {
                    string hCurrentPass = Helper.EncryptPassword(modifiedModel.CurrentPassword);
                    if (!hCurrentPass.Equals(user.Password))
                    {
                       errorMessage = "The current password is wrong";
                    }
                    if (!modifiedModel.NewPassword.Equals(modifiedModel.ConfirmPassword))
                    {
                        errorMessage = "The confirmed password does not match";
                    }

                    string hNewPass = Helper.EncryptPassword(modifiedModel.NewPassword);
                    user.Password = hNewPass;
                    result = _userServices.UpdateUser(user);
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public UserSettingViewModel GetUserSetting(Guid UserId) {
            UserSettingViewModel userSetting = _userServices.GetUserSettingsByUserID(UserId).Select(o => new UserSettingViewModel
            {
                ShowSKUs = o.ShowSKUs.Equals("Display") ? true : false,
                ShowAddress = o.ShowAddress.Equals("Display") ? true : false,
                ShowPrice = o.ShowPrice.Equals("Display") ? true : false,
                ShowWholesalePrice = o.ShowWholesalePrice.Equals("Display") ? true : false,
                RetailMultiplier = o.RetailMultiplier ?? 0
            }).FirstOrDefault();
            return userSetting;
        }

        public async Task<bool> UpdateUserSetting(UserSettingViewModel userSetting, Guid UserId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = true;
                try
                {
                    var user = await _userServices.GetUsers_Queryable().Where(u => u.ID == UserId).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        //update setting
                        user.ShowAddress = userSetting.ShowAddress;
                        user.ShowPrice = userSetting.ShowPrice;
                        user.ShowSKUs = userSetting.ShowSKUs;
                        user.ShowWholesalePrice = userSetting.ShowWholesalePrice;
                        result = result && _userServices.UpdateUser(user);
                    }

                    if (userSetting.RetailMultiplier > 0) {
                        var designerUS = _userServices.GetDesignerUS_Queryable().Where(o => o.UserID == UserId).FirstOrDefault();
                        if (designerUS != null)
                        {
                            //update designer retail multiplier
                            designerUS.RetailMultiplier = userSetting.RetailMultiplier;
                            result = result && await _userServices.UpdateDesigner(designerUS);
                        }
                    }
                    
                    if (result)
                    {
                        scope.Complete();
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    scope.Dispose();
                    throw ex;
                }
                return result;
            }
        }

        public async Task<DealerInfoViewModel> GetDealerInfo(Guid UserId)
        {
            try
            {
                var dealer = await _dealerServices.GetDealerByUserId_Queryable(UserId).FirstOrDefaultAsync();                
                if (dealer != null)
                {
                    DealerInfoViewModel dealerInfoView = new DealerInfoViewModel();
                    var stores = dealer.Stores.Select(s => new DealerStoreViewModel
                    {
                        ID = s.ID,
                        Name = s.Name,
                        Phone = s.Phone,
                        Email = s.Email,
                        Website = s.Website,
                        PostalCode = s.PostalCode,
                        DateModified = s.DateModified,
                        Address1 = s.Address1,
                        Address2 = s.Address2,
                        CityName = s.City.Name,
                        RegionName = s.City.Region.Name,
                        CountryName = s.City.Region.Country.Name,
                    }).ToList();
                    if (stores.Count > 0)
                    {
                        foreach (var store in stores)
                        {
                            var Associates = await _sasStoreServices.GetSalesAssociate_Stores().Where(o => o.Store_ID == store.ID && o.DealerApproved == true)
                                .Select(o => new SalesAssociateStoreForDealerInfoViewModel
                                {
                                    SalesAssociate_ID = o.SalesAssociate_ID,
                                    Firstname = o.SalesAssociate.User.Firstname,
                                    Lastname = o.SalesAssociate.User.Lastname,
                                    Email = o.SalesAssociate.User.Email,
                                    Username = o.SalesAssociate.User.Username,
                                    DealerApproved = o.DealerApproved
                                }).OrderByDescending(o => o.DealerApproved).ToListAsync();
                            store.Associates = Associates;
                            var PendingAssociates = await _sasStoreServices.GetSalesAssociate_Stores().Where(o => o.Store_ID == store.ID && o.DealerApproved == false)
                                .Select(o => new SalesAssociateStoreForDealerInfoViewModel
                                {
                                    SalesAssociate_ID = o.SalesAssociate_ID,
                                    Firstname = o.SalesAssociate.User.Firstname,
                                    Lastname = o.SalesAssociate.User.Lastname,
                                    Email = o.SalesAssociate.User.Email,
                                    Username = o.SalesAssociate.User.Username,
                                    DealerApproved = o.DealerApproved
                                }).OrderByDescending(o => o.DealerApproved).ToListAsync();
                            var dealerStore = await _storeServices.GetStores_Queryable().Where(s => s.ID == store.ID).Select(d => d.Dealers.Select(ds => new DealerStoreForDealerInfoViewModel
                            {
                                UserId = ds.User.ID,
                                Username = ds.User.Username
                            }).ToList()).FirstOrDefaultAsync();
                            store.Dealers = dealerStore;
                            store.PendingAssociates = PendingAssociates;
                        }
                    }
                    dealerInfoView.Stores = stores;
                    //TODO
                    //var billingAddress = _dealerServices.GetDealerBillingAddressByUserID(UserId).Select(b => new TaUserAddressViewModel
                    //{
                    //    AddressLine1 = b.AddressLine1,
                    //    AddressLine2 = b.AddressLine2,
                    //    PostalCode = b.PostalCode,
                    //    Phone = b.Phone,
                    //    Fax = b.Fax,
                    //    City = b.City,
                    //    Region = b.Region,
                    //    Country = b.Country
                    //}).ToList();
                    //dealerInfoView.BillingAddress = billingAddress;
                    //var shippingAddress = _dealerServices.GetDealerShippingAddressByUserID(UserId).Select(s => new TaUserAddressViewModel
                    //{
                    //    AddressLine1 = s.AddressLine1,
                    //    AddressLine2 = s.AddressLine2,
                    //    PostalCode = s.Postalcode,
                    //    Phone = s.Phone,
                    //    Fax = s.Fax,
                    //    City = s.City,
                    //    Region = s.Region,
                    //    Country = s.Country,
                    //    CityId = s.City_ID,
                    //    IsDefault = s.IsDefault == 1 ? true : false
                    //}).ToList();
                    //dealerInfoView.ShippingAddress = shippingAddress;
                    dealerInfoView.PriceMultiplier = await GetPriceMultiplier(UserId); ;
                    return dealerInfoView;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RevokeAssociate(Guid salesId, Guid storeId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = true;
                try
                {
                    var ss = await _sasStoreServices.GetSalesAssociate_Stores().Where(o => o.SalesAssociate_ID == salesId && o.Store_ID == storeId).FirstOrDefaultAsync();
                    if (ss != null)
                    {
                        result = await _sasStoreServices.RevokeAssociate(ss);
                    }
                    else
                    {
                        result = false;
                    }
                    if (result)
                    {
                        scope.Complete();
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    scope.Dispose();
                    throw ex;
                }
                return result;
            }
        }

        public async Task<bool> ApproveAssociateRequest(Guid salesId, Guid storeId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = true;
                try
                {
                    var ss = await _sasStoreServices.GetSalesAssociate_Stores().Where(o => o.SalesAssociate_ID == salesId && o.Store_ID == storeId).FirstOrDefaultAsync();
                    if (ss != null)
                    {
                        result = await _sasStoreServices.ApproveAssociateRequest(ss);
                    }
                    else
                    {
                        result = false;
                    }
                    if (result)
                    {
                        scope.Complete();
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    scope.Dispose();
                    throw ex;
                }
                return result;
            }
        }

        public async Task<bool> UpdatePriceMultiplier(double price, List<Store> stores)
        {
            var result = true;
            foreach (var store in stores)
            {
                store.PriceMultiplier = price;
                result = await _dealerServices.UpdateDealerStore(store);
                if (!result)
                {
                    return result;
                }
            }
            return result;
        }

        public async Task<bool> UpdateDealerSettingPage(DealerSettingPageUpdateModel dealerSettingPageUpdate, Guid UserId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = false;
                try
                {
                    var dealer = await _dealerServices.GetDealerByUserId_Queryable(UserId).FirstOrDefaultAsync();
                    if (dealer != null)
                    {
                        var updatePriceMultiplier = true;
                        if (dealerSettingPageUpdate.ChangePriceMultiplier && dealerSettingPageUpdate.PriceMultiplier > 0)
                        {
                            var stores = await _dealerServices.GetUserStoreID(UserId).ToListAsync();
                            if (stores.Count > 0)
                            {
                                updatePriceMultiplier = await UpdatePriceMultiplier(dealerSettingPageUpdate.PriceMultiplier, stores);
                            }
                        }
                        var updateDealer = await _dealerServices.UpdateDealer(dealer);
                        if (updatePriceMultiplier && updateDealer)
                        {
                            result = true;
                        }
                    }
                    if (result)
                    {
                        scope.Complete();
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                    scope.Dispose();
                    throw ex;
                }
                return result;
            }
        }

        public async Task<ValidatedUser> VerifyRegisterEmail(Guid userId, string IpAddress)
        {
            ValidatedUser validatedUser = null;
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = await _userServices.GetUsers_Queryable().Where(o => o.ID == userId && o.EmailVerified == false).FirstOrDefaultAsync();
                    if (user != null)
                    {
                        user.EmailVerified = true;
                        var updatedUser = _userServices.UpdateUser(user);
                        if (updatedUser)
                        {
                            validatedUser = new ValidatedUser
                            {
                                ID = user.ID,
                                EmailVerified = user.EmailVerified,
                                AccountEnabled = user.AccountEnabled,
                                Firstname = user.Firstname,
                                Email = user.Email,
                                UserTypeViewModel = new UserTypeViewModel
                                {
                                    Name = user.UserType?.Name?.Replace(" ", String.Empty) ?? LocalUserType.Consumer
                                }
                            };
                            //Get Country Id
                            var countryId = await _dataServices.GetCountryId(IpAddress);
                            //Get User region
                            JWTIdentityViewModel jwtUser = new JWTIdentityViewModel
                            {
                                UserId = validatedUser.ID,
                                UserType = validatedUser.UserTypeViewModel.Name,
                                UserName = validatedUser.Username,
                                FirstName = validatedUser.Firstname,
                                LastName = validatedUser.Lastname,
                                Email = validatedUser.Email
                            };
                            var userRegion = GetUserRegion(countryId, validatedUser.ID, validatedUser.UserTypeViewModel.Name);
                            validatedUser.Region = userRegion;

                            //Move to Register user
                            //add to email subscriber
                            //Helper.AddNewUserMember(user.Email, GetUserRegion(countryId, Guid.Empty, LocalUserType.Consumer));
                        }
                    }
                    scope.Complete();
                }
                catch(Exception ex)
                {
                    scope.Dispose();
                    throw new Exception(ex.Message, ex);
                }
            }
            return validatedUser;
        }

        public async Task<double> GetPriceMultiplier(Guid UserId)
        {
            var storeIds = _dealerServices.GetUserStoreID(UserId);
            if (await storeIds.CountAsync() < 1) return 3.0;
            Guid firstStoreId = storeIds.First().ID;
            var store = await _storeServices.GetStorebyId(firstStoreId).SingleAsync();
            var storePrice = store.PriceMultiplier == 0 ? 3.0 : store.PriceMultiplier;
            return storePrice;
        }
    }
}
