using TA.Data.Models;
using TA.Helpers;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TA.Data.Repositories
{
    public class HR_Recruitment_CareerRepository : RepositoryERP<HR_Recruitment_Career>, IHR_Recruitment_CareerRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        public HR_Recruitment_CareerRepository(TheodoreAlexander_ERPContext context) : base(context)
        {
            _context = context;
        }
        public override void Initialization(HR_Recruitment_Career model)
        {
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (model.DateUpdated == null)
            {
                model.DateUpdated = AppGlobal.InitializationDateTime;
            }
            if (model.Active == null)
            {
                model.Active = false;
            }
            if (model.IsBanner == true)
            {
                model.MediaSource = model.MediaSource + "[Banner]";
            }
            if (model.IsFacebook == true)
            {
                model.MediaSource = model.MediaSource + "[Facebook]";
            }
            if (model.IsZalo == true)
            {
                model.MediaSource = model.MediaSource + "[Zalo]";
            }
            if (model.IsFriend == true)
            {
                model.MediaSource = model.MediaSource + "[Friend]";
            }
        }
        public override int Add(HR_Recruitment_Career model)
        {
            int result = AppGlobal.InitializationNumber;
            int check = AppGlobal.InitializationNumber;
            if (!string.IsNullOrEmpty(model.FullName))
            {
                check = check + 1;
            }
            if (!string.IsNullOrEmpty(model.Phone))
            {
                check = check + 1;
            }
            if (!string.IsNullOrEmpty(model.JobFunction))
            {
                check = check + 1;
            }
            if (check == 3)
            {
                Initialization(model);
                _context.Set<HR_Recruitment_Career>().Add(model);
                result = _context.SaveChanges();
            }
            return result;
        }                
        public List<HR_Recruitment_Career> GetByRecommendPhoneToList(string recommendPhone)
        {
            List<HR_Recruitment_Career> result = new List<HR_Recruitment_Career>();
            if (!string.IsNullOrEmpty(recommendPhone))
            {
                recommendPhone = recommendPhone.Trim();
                result = _context.Set<HR_Recruitment_Career>().Where(model => model.RecommendPhone == recommendPhone).OrderByDescending(item => item.DateUpdated).ToList();
            }
            return result;
        }
        public List<HR_Recruitment_Career> GetByRecommendPhoneAndSearchStringToList(string recommendPhone, string searchString)
        {
            List<HR_Recruitment_Career> result = new List<HR_Recruitment_Career>();
            recommendPhone = recommendPhone.Trim();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetByRecommendPhoneToList(recommendPhone);
            }
            else
            {
                searchString = searchString.Trim();
                SqlParameter[] parameters =
                   {
                new SqlParameter("@RecommendPhone",recommendPhone),
                new SqlParameter("@SearchString",searchString),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_Recruitment_CareerSelectByRecommendPhoneAndSearchString", parameters);
                result = SQLHelper.ToList<HR_Recruitment_Career>(dt);
            }
            return result;
        }
        public List<HR_Recruitment_Career> GetBySearchStringToList(string searchString)
        {
            List<HR_Recruitment_Career> result = new List<HR_Recruitment_Career>();
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
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_HR_Recruitment_CareerSelectBySearchString", parameters);
                result = SQLHelper.ToList<HR_Recruitment_Career>(dt);
            }
            return result;
        }
    }
}

