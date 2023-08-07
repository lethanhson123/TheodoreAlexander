using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace TA.Data2021.Models
{
    public partial class TheodoreAlexander_NewContext : DbContext
    {
        public TheodoreAlexander_NewContext()
            : base("Persist Security Info=True;User ID=sa;Password=Passw0rd4WEB;database=TheodoreAlexander_New;data source=localhost;")
        {
        }
        public virtual DbSet<TA.Data2021.Models.Brand> Brand { get; set; }
        public virtual DbSet<TA.Data2021.Models.Collection> Collection { get; set; }
        public virtual DbSet<TA.Data2021.Models.Item> Item { get; set; }
        public virtual DbSet<TA.Data2021.Models.Item_Fabric> Item_Fabric { get; set; }
        public virtual DbSet<TA.Data2021.Models.LifeStyle> LifeStyle { get; set; }
        public virtual DbSet<TA.Data2021.Models.Style> Style { get; set; }
        public virtual DbSet<TA.Data2021.Models.RoomAndUsage> RoomAndUsage { get; set; }
        public virtual DbSet<TA.Data2021.Models.Shape> Shape { get; set; }
        public virtual DbSet<TA.Data2021.Models.Type> Type { get; set; }
        public virtual DbSet<TA.Data2021.Models.Designer> Designer { get; set; }
        public virtual DbSet<TA.Data2021.Models.ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<TA.Data2021.Models.ShoppingCart_Item> ShoppingCart_Item { get; set; }
        public virtual DbSet<TA.Data2021.Models.MarketingResourceCategory> MarketingResourceCategory { get; set; }
        public virtual DbSet<TA.Data2021.Models.MarketingResource> MarketingResource { get; set; }
        public virtual DbSet<TA.Data2021.Models.MarketingResourceDetail> MarketingResourceDetail { get; set; }
        public virtual DbSet<TA.Data2021.Models.Dealer_Taus> Dealer_Taus { get; set; }
        public virtual DbSet<TA.Data2021.Models.Banner> Banner { get; set; }
        public virtual DbSet<TA.Data2021.Models.BannerDetail> BannerDetail { get; set; }
    }
}
