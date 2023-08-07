using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TA.Data.Models;
using TA.Helpers;

namespace TA.Data.Repositories
{
    public class GhostBlogRepository : RepositoryERP<GhostBlog>, IGhostBlogRepository
    {
        private readonly TheodoreAlexander_ERPContext _context;
        private readonly TheodoreAlexander_NewContext _contextNew;
        public GhostBlogRepository(TheodoreAlexander_NewContext contextNew, TheodoreAlexander_ERPContext context) : base(context)
        {
            _contextNew = contextNew;
            _context = context;
        }
        public override void Initialization(GhostBlog model)
        {
            model.DateUpdated = AppGlobal.InitializationDateTime;
            if (model.DateCreated == null)
            {
                model.DateCreated = AppGlobal.InitializationDateTime;
            }
            if (model.Active == null)
            {
                model.Active = true;
            }
            if (string.IsNullOrEmpty(model.URLCode))
            {
                try
                {
                    model.URLCode = model.Note.Split('/')[model.Note.Split('/').Length - 2];
                }
                catch
                {
                    model.URLCode = model.Note.Replace(@"https://tablog.ghost.io/", @"");
                    model.URLCode = model.URLCode.Replace(@"/", @"");
                }
            }
            //if (string.IsNullOrEmpty(model.URLCode))
            //{
            //    model.URLCode = AppGlobal.SetName(model.Title);
            //}
            if (string.IsNullOrEmpty(model.METADescription))
            {
                model.METADescription = model.Description;
            }
            if (string.IsNullOrEmpty(model.METAKeyword))
            {
                model.METAKeyword = model.Description;
            }
            if (string.IsNullOrEmpty(model.URLImage))
            {
                model.URLImage = model.Image;
            }
            if (string.IsNullOrEmpty(model.Author))
            {
                model.Author = "Theodore Alexander";
            }
            if (string.IsNullOrEmpty(model.DatePostString))
            {
                model.DatePostString = model.DatePost.Value.ToString("MMMM") + " " + model.DatePost.Value.Day + ", " + model.DatePost.Value.Year;
            }
            if (string.IsNullOrEmpty(model.ShareFacebook))
            {
                model.ShareFacebook = "https://www.facebook.com/sharer/sharer.php?u=" + AppGlobal.DomainURLLIVE + AppGlobal.Blog + "/" + model.URLCode + ".html";
            }
            if (string.IsNullOrEmpty(model.ShareTwitter))
            {
                model.ShareTwitter = "https://twitter.com/intent/tweet?text=" + model.Title + "&url=" + AppGlobal.DomainURLLIVE + AppGlobal.Blog + "/" + model.URLCode + ".html";
            }
            if (string.IsNullOrEmpty(model.SharePinterest))
            {
                model.SharePinterest = "https://www.pinterest.com/pin/create/button?url=" + AppGlobal.DomainURLLIVE + AppGlobal.Blog + "/" + model.URLCode + ".html&media=" + model.Image + "&description=" + model.Title;
            }
        }
        public override int Add(GhostBlog model)
        {
            Initialization(model);
            GhostBlog modelExist = GetByURLCode(model.URLCode);
            if ((modelExist == null) || (modelExist.ID == 0))
            {
                _context.Set<GhostBlog>().Add(model);
            }
            return _context.SaveChanges();
        }
        public GhostBlog GetByURLCode(string URLCode)
        {
            GhostBlog result = new GhostBlog();
            if (!string.IsNullOrEmpty(URLCode))
            {
                URLCode = URLCode.Split('.')[0];
                URLCode = URLCode.Split('/')[URLCode.Split('/').Length - 1];
                result = _context.Set<GhostBlog>().AsNoTracking().FirstOrDefault(model => model.URLCode == URLCode);
            }
            return result;
        }
        public override List<GhostBlog> GetAllToList()
        {
            var result = _context.Set<GhostBlog>().OrderByDescending(model => model.DatePost).ToList();
            return result ?? new List<GhostBlog>();
        }
        public List<GhostBlog> GetBySearchStringToList(string searchString)
        {
            List<GhostBlog> result = new List<GhostBlog>();
            if (string.IsNullOrEmpty(searchString))
            {
                result = GetAllToList();
            }
            else
            {
                searchString = searchString.Trim();
                result = _context.Set<GhostBlog>().Where(model => model.Title.Contains(searchString) || model.URLCode.Contains(searchString) || model.Image.Contains(searchString) || model.DatePost.Value.ToString().Contains(searchString)).OrderByDescending(model => model.DatePost).ToList();
            }
            return result;
        }
        public List<GhostBlog> GetByNumberToList(int number)
        {
            List<GhostBlog> result = new List<GhostBlog>();
            if (number == 0)
            {
                result = GetAllToList();
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Number",number),
                };
                DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_GhostBlogSelectByNumber", parameters);
                result = SQLHelper.ToList<GhostBlog>(dt);
            }
            return result;
        }
        public List<GhostBlog> GetByNumberAndIDToList(int number, int ID)
        {
            List<GhostBlog> result = new List<GhostBlog>();
            SqlParameter[] parameters =
            {
                    new SqlParameter("@Number",number),
                    new SqlParameter("@ID",ID),
            };
            DataTable dt = SQLHelper.Fill(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_GhostBlogSelectByNumberAndID", parameters);
            result = SQLHelper.ToList<GhostBlog>(dt);
            return result;
        }
        public string DeleteAllItems()
        {
            string result = AppGlobal.InitializationString;
            result = SQLHelper.ExecuteNonQuery(AppGlobal.TheodoreAlexander_NewSQLServerConectionString, "sp_GhostBlogDeleteAllItems");
            return result;
        }
    }
}

