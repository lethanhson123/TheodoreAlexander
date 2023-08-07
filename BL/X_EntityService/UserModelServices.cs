using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.ViewModels;
using BL.CustomExceptions;
using System.Data.Entity.Core.Objects;

namespace BL.EntityService
{
    public class UserModelServices : ITAWModelService<Designer_Taus, Guid>
    {
        public UserModelServices(TheodoreAlexanderEntities ctx):base(ctx)
        {
        }

        public IQueryable<Designer_Taus> GetDesignerUS()
        {
            return _ctx.Designer_Taus.AsNoTracking();
        }

        public IQueryable<Designer_Taus> GetDesignerUS_Queryable()
        {
            return _ctx.Designer_Taus;
        }

        public async Task<bool> UpdateDesigner(Designer_Taus designer)
        {
            try
            {
                _ctx.Entry(designer).State = EntityState.Modified;
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                _ctx.Users.Add(user);
                return await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<UserType> GetAllUserType()
        {
            return _ctx.UserTypes.AsNoTracking();
        }

        public IQueryable<User> GetUsers_Queryable()
        {
            return _ctx.Users;
        }

        public ObjectResult<usp_GetUserSettingsByUserID_Result> GetUserSettingsByUserID(Guid UserId)
        {
            return _ctx.usp_GetUserSettingsByUserID(UserId);
        }

        public async Task<User> GetUserByLoginNameAndPassword(User model)
        {
            User user = await _ctx.Users.FirstOrDefaultAsync(o => o.Username == model.Username && o.Password == model.Password);
            if (user == null) {//try to get by email
                user = await _ctx.Users.FirstOrDefaultAsync(o => o.Email == model.Username && o.Password == model.Password);
            }
            return user;
        }

        public User GetUserById(Guid id)
        {
            return _ctx.Users.Where(o => o.ID == id).FirstOrDefault();
        }

        public IQueryable<User> GetUserEmails(string email)
        {
            return _ctx.Users.Where(o => o.Email == email);
        }

        public IQueryable<User> GetUserNames(string userName)
        {
            return _ctx.Users.Where(o => o.Username == userName);
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _ctx.Entry(user).State = EntityState.Modified;
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObjectResult<usp_GetAccountDataByUserID_Result1> GetAccountDataByUserID(Guid UserId)
        {
            return _ctx.usp_GetAccountDataByUserID(UserId);
        }

        public override IQueryable<Designer_Taus> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Designer_Taus> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(Designer_Taus t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Designer_Taus t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
