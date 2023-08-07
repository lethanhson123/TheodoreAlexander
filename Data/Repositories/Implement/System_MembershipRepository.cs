using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class System_MembershipRepository : RepositoryERP<System_Membership>, ISystem_MembershipRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public System_MembershipRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(System_Membership model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (model.Active == null)
            {
                model.Active = false;
            }
            if (model.Email.Contains("@") == false)
            {
                model.Email = model.Email + "@theodorealexander.com";
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                model.UserName = model.Email;
            }
            if (string.IsNullOrEmpty(model.DisplayName))
            {
                model.DisplayName = model.UserName;
            }
            if (string.IsNullOrEmpty(model.GUICode))
            {
                model.GUICode = AppGlobal.InitializationGUICode;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                model.Password = "0";
            }
        }
        private static void EncryptPassword(System_Membership model)
        {
            model.Password = SecurityHelper.Encrypt(model.GUICode, model.Password);
        }
        public static void DecryptPassword(System_Membership model)
        {
            model.Password = SecurityHelper.Decrypt(model.GUICode, model.Password);
        }
        public override int Add(System_Membership model)
        {
            int result = 0;
            Initialization(model);
            System_Membership checkMembership = GetByEmail(model.Email);
            if (checkMembership != null)
            {
                result = result + 1;
            }
            checkMembership = GetByUserName(model.UserName);
            if (checkMembership != null)
            {
                result = result + 1;
            }
            if (result == 0)
            {
                EncryptPassword(model);
                _context.Set<System_Membership>().Add(model);
                result = _context.SaveChanges();
            }
            return result;
        }
        public override int Update(System_Membership model)
        {
            System_Membership existModel = GetByID(model.ID);
            if (existModel != null)
            {
                Initialization(model);
                if (model.Password != existModel.Password)
                {
                    EncryptPassword(model);
                }
                existModel = model;
                _context.Set<System_Membership>().Update(existModel);
            }
            return _context.SaveChanges();
        }
        public System_Membership GetByEmail(string email)
        {
            System_Membership result = new System_Membership();
            if (!string.IsNullOrEmpty(email))
            {
                result = _context.Set<System_Membership>().AsNoTracking().FirstOrDefault(model => model.Email == email);
            }
            return result;
        }
        public System_Membership GetByUserName(string userName)
        {
            System_Membership result = new System_Membership();
            if (!string.IsNullOrEmpty(userName))
            {

                result = _context.Set<System_Membership>().AsNoTracking().FirstOrDefault(model => model.UserName == userName);
            }
            return result;
        }
        public List<System_Membership> GetBySearchStringToList(string searchString)
        {
            List<System_Membership> result = new List<System_Membership>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                result = _context.Set<System_Membership>().Where(model => model.DisplayName.Contains(searchString) || model.Email.Contains(searchString) || model.UserName.Contains(searchString)).ToList();
            }
            return result.OrderBy(model => model.UserName).ToList();
        }
        public System_Membership AuthenticationByEmailAndPasswordAndURL(string email, string password, string urlDestination)
        {
            System_Membership result = new System_Membership();
            result = _context.Set<System_Membership>().AsNoTracking().FirstOrDefault(model => model.Email == email && model.Active == true);
            bool check = false;
            if (result != null)
            {
                if (string.IsNullOrEmpty(result.GUICode))
                {
                    result.Password = password;
                    Update(result);
                }
                string passwordDecrypt = SecurityHelper.Decrypt(result.GUICode, result.Password);
                if (passwordDecrypt.Equals(password))
                {
                    check = true;
                }
            }
            if (check == true)
            {
                System_AuthenticationToken system_AuthenticationToken = new System_AuthenticationToken();
                system_AuthenticationToken.MembershipID = result.ID;
                system_AuthenticationToken.AuthenticationToken = AppGlobal.InitializationGUICode;
                system_AuthenticationToken.DateBegin = AppGlobal.InitializationDateTime;
                system_AuthenticationToken.DateEnd = system_AuthenticationToken.DateBegin.Value.AddMonths(1);
                system_AuthenticationToken.DateCreated = AppGlobal.InitializationDateTime;
                system_AuthenticationToken.DateCreated = AppGlobal.InitializationDateTime;
                system_AuthenticationToken.Active = true;
                _context.Set<System_AuthenticationToken>().Add(system_AuthenticationToken);
                int resultSave = _context.SaveChanges();
                result.Note = system_AuthenticationToken.AuthenticationToken;
                result.CodeManage = urlDestination + "?AuthenticationToken=" + system_AuthenticationToken.AuthenticationToken;
            }
            else
            {
                result = new System_Membership();
            }    
            return result;
        }
    }
}

