using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TA.Data.Models
{
    public partial class TheodoreAlexander_NewContext : DbContext
    {
        public TheodoreAlexander_NewContext()
        {
        }

        public TheodoreAlexander_NewContext(DbContextOptions<TheodoreAlexander_NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TA.Data.Models.Feature2D> Feature2D { get; set; }
        public virtual DbSet<TA.Data.Models.Feature3D> Feature3D { get; set; }
        public virtual DbSet<TA.Data.Models.Care> Care { get; set; }
        public virtual DbSet<TA.Data.Models.Century> Century { get; set; }
        public virtual DbSet<TA.Data.Models.ColourAndFinish> ColourAndFinish { get; set; }
        public virtual DbSet<TA.Data.Models.Geography> Geography { get; set; }
        public virtual DbSet<TA.Data.Models.HistoricalStyle> HistoricalStyle { get; set; }
        public virtual DbSet<TA.Data.Models.ProcessAndTechnique> ProcessAndTechnique { get; set; }        
        public virtual DbSet<TA.Data.Models.City> City { get; set; }
        public virtual DbSet<TA.Data.Models.Continent> Continent { get; set; }
        public virtual DbSet<TA.Data.Models.Country> Country { get; set; }
        public virtual DbSet<TA.Data.Models.Item> Item { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Status> Item_Status { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Price> Item_Price { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Fabric> Item_Fabric { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Shape> Item_Shape { get; set; }
        public virtual DbSet<TA.Data.Models.Item_2Dfeature> Item_2Dfeature { get; set; }
        public virtual DbSet<TA.Data.Models.Item_3Dfeature> Item_3Dfeature { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Care> Item_Care { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Century> Item_Century { get; set; }
        public virtual DbSet<TA.Data.Models.Item_ColourAndFinish> Item_ColourAndFinish { get; set; }
        public virtual DbSet<TA.Data.Models.Item_Geography> Item_Geography { get; set; }
        public virtual DbSet<TA.Data.Models.Item_HistoricalStyle> Item_HistoricalStyle { get; set; }
        public virtual DbSet<TA.Data.Models.Item_ProcessAndTechnique> Item_ProcessAndTechnique { get; set; }
        public virtual DbSet<TA.Data.Models.RelatedItem> RelatedItem { get; set; }
        public virtual DbSet<TA.Data.Models.RelatedSkuForSpecialGroup> RelatedSkuForSpecialGroup { get; set; }
        public virtual DbSet<TA.Data.Models.SKUListingForSizeAvailability> SKUListingForSizeAvailability { get; set; }
        public virtual DbSet<TA.Data.Models.Region> Region { get; set; }
        public virtual DbSet<TA.Data.Models.Store> Store { get; set; }
        public virtual DbSet<TA.Data.Models.Collection> Collection { get; set; }
        public virtual DbSet<TA.Data.Models.LifeStyle> LifeStyle { get; set; }
        public virtual DbSet<TA.Data.Models.Style> Style { get; set; }
        public virtual DbSet<TA.Data.Models.Shape> Shape { get; set; }
        public virtual DbSet<TA.Data.Models.Type> Type { get; set; }
        public virtual DbSet<TA.Data.Models.User> User { get; set; }
        public virtual DbSet<TA.Data.Models.Designer> Designer { get; set; }
        public virtual DbSet<TA.Data.Models.Brand> Brand { get; set; }
        public virtual DbSet<TA.Data.Models.RoomAndUsage> RoomAndUsage { get; set; }
        public virtual DbSet<TA.Data.Models.UPHFabric> UPHFabric { get; set; }
        public virtual DbSet<TA.Data.Models.UPHColour> UPHColour { get; set; }
        public virtual DbSet<TA.Data.Models.Material> Material { get; set; }
        public virtual DbSet<TA.Data.Models.OptionGroup> OptionGroup { get; set; }
        public virtual DbSet<TA.Data.Models.ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<TA.Data.Models.ShoppingCart_Item> ShoppingCart_Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(TA.Helpers.AppGlobal.TheodoreAlexander_NewSQLServerConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
