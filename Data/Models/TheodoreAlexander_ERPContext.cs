using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Data.Models
{
    public partial class TheodoreAlexander_ERPContext : DbContext
    {
        public TheodoreAlexander_ERPContext()
        {
        }

        public TheodoreAlexander_ERPContext(DbContextOptions<TheodoreAlexander_ERPContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TA.Data.Models.HR_Block> HR_Block { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Department> HR_Department { get; set; }
        public virtual DbSet<TA.Data.Models.HR_District> HR_District { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Division> HR_Division { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Duty> HR_Duty { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Employee> HR_Employee { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Employee_HistoryWork> HR_Employee_HistoryWork { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Group> HR_Group { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Province> HR_Province { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Recruitment_Career> HR_Recruitment_Career { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Recruitment_Introduce> HR_Recruitment_Introduce { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Status> HR_Status { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Team> HR_Team { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Ward> HR_Ward { get; set; }
        public virtual DbSet<TA.Data.Models.HR_WorkingStatus> HR_WorkingStatus { get; set; }
        public virtual DbSet<TA.Data.Models.HR_Covid> HR_Covid { get; set; }
        public virtual DbSet<TA.Data.Models.HR_CovidLocal> HR_CovidLocal { get; set; }
        public virtual DbSet<TA.Data.Models.HR_CovidResult> HR_CovidResult { get; set; }
        public virtual DbSet<TA.Data.Models.HR_CovidTest> HR_CovidTest { get; set; }
        public virtual DbSet<TA.Data.Models.HR_CovidType> HR_CovidType { get; set; }
        public virtual DbSet<TA.Data.Models.MarketingResource> MarketingResource { get; set; }
        public virtual DbSet<TA.Data.Models.MarketingResourceCategory> MarketingResourceCategory { get; set; }
        public virtual DbSet<TA.Data.Models.MarketingResourceDetail> MarketingResourceDetail { get; set; }
        public virtual DbSet<TA.Data.Models.System_Application> System_Application { get; set; }
        public virtual DbSet<TA.Data.Models.System_AuthenticationApplication> System_AuthenticationApplication { get; set; }
        public virtual DbSet<TA.Data.Models.System_AuthenticationMenu> System_AuthenticationMenu { get; set; }
        public virtual DbSet<TA.Data.Models.System_AuthenticationToken> System_AuthenticationToken { get; set; }
        public virtual DbSet<TA.Data.Models.System_Membership> System_Membership { get; set; }
        public virtual DbSet<TA.Data.Models.System_Menu> System_Menu { get; set; }
        public virtual DbSet<TA.Data.Models.Banner> Banner { get; set; }
        public virtual DbSet<TA.Data.Models.BannerDetail> BannerDetail { get; set; }
        public virtual DbSet<TA.Data.Models.GhostBlog> GhostBlog { get; set; }
        public virtual DbSet<TA.Data.Models.SEOBlog> SEOBlog { get; set; }
        public virtual DbSet<TA.Data.Models.SEOBlogItem> SEOBlogItem { get; set; }
        public virtual DbSet<TA.Data.Models.SEOBlogStore> SEOBlogStore { get; set; }
        public virtual DbSet<TA.Data.Models.SEOBlogTemplate> SEOBlogTemplate { get; set; }
        public virtual DbSet<TA.Data.Models.SEOKeyword> SEOKeyword { get; set; }
        public virtual DbSet<TA.Data.Models.SEOBlogType> SEOBlogType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(TA.Helpers.AppGlobal.TheodoreAlexander_ERPSQLServerConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
