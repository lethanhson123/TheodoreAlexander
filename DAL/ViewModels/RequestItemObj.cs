using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class OriginRequestObj
    {
        public string BrandIds { get; set; }
        public string CollectionIds { get; set; }
        public string RoomIds { get; set; }
        public string TypeIds { get; set; }
        public string LifeStyleIds { get; set; }
        public string StyleIds { get; set; }
        public string DesignerIds { get; set; }
        public string ShapeIds { get; set; }
        public string ColourAndFinishIds { get; set; }
        public string OptionGroupIds { get; set; }
        public string SearchKey { get; set; }
        public bool IsCustomPalette { get; set; } = false;
        public bool NewOnly { get; set; } = false;
        public bool DefaultItemOnly { get; set; } = true;
        public bool IsStockProgram { get; set; } = false;
        public bool IsStocked { get; set; } = false;
        public bool Extending { get; set; } = false;
        public bool IsBestSeller { get; set; } = false;
        public DimensionRangeModel DimensionRange { get; set; }
    }
    public class RequestItemObj:OriginRequestObj
    {
        public int PageSize { get; set; } = 12;
        public int PageNum { get; set; } = 1;
        public string OrderBy { get; set; } = "ProductName";
        public bool Ascending { get; set;}
    }
    public class CountItemObj: OriginRequestObj
    {

    }
    public class CountItemForSidebarRequestObj
    {
        public string CountBy { get; set; }
        public CountItemObj IgnoreCountby { get; set; }
        public CountItemObj IncludeCountby { get; set; }
    }
}
