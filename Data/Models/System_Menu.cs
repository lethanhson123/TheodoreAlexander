using System;
namespace TA.Data.Models
{
    public partial class System_Menu : BaseModelERP
    {
        public int? ApplicationID { get; set; }
        public string Menu { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int? SortOrder { get; set; }
    }
}

