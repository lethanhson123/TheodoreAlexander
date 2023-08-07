using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class DimensionRequestObj
    {
        public string BrandIds { get; set; }
        public string Brands { get; set; }
        public string CollectionIds { get; set; }
        public string Collections { get; set; }
        public string RoomIds { get; set; }
        public string Rooms { get; set; }
        public string TypeIds { get; set; }
        public string Types { get; set; }
        public string LifeStyleIds { get; set; }
        public string LifeStyles { get; set; }
        public string StyleIds { get; set; }
        public string Styles { get; set; }
        public string DesignerIds { get; set; }
        public string Designers { get; set; }
        public string ShapeIds { get; set; }
        public string Shapes { get; set; }
        public string ColourAndFinishIds { get; set; }
        public string ColourAndFinishes { get; set; }
        public string OptionGroupIds { get; set; }
        public string OptionGroups { get; set; }
        public string SearchKey { get; set; }
        public bool IsCustomPalette { get; set; } = false;
        public bool NewOnly { get; set; } = false;
        public bool DefaultItemOnly { get; set; } = true;
        public bool IsStockProgram { get; set; } = false;
        public bool IsStocked { get; set; } = false;
        public bool Extending { get; set; } = false;
        public bool IsBestSeller { get; set; } = false;
    }
    public class Dimension
    {
        public decimal WidthMin { get; set; }
        public decimal WidthMax { get; set; }
        public decimal HeightMin { get; set; }
        public decimal HeightMax { get; set; }
        public decimal DepthMin { get; set; }
        public decimal DepthMax { get; set; }
        public Dimension()
        {
            WidthMin = 0;
            WidthMax = 0;
            HeightMax = 0;
            HeightMin = 0;
            DepthMax = 0;
            DepthMin = 0;
        }
    }
    public class DimensionRangeModel:Dimension
    {
        public bool IsInch { get; set; } = true;
        public DimensionRangeModel():base()
        {

        }
    }
    public class DimensionCM : Dimension
    {
        public DimensionCM():base()
        {

        }
    }
    public class DimensionInch : Dimension
    {
        public DimensionInch():base()
        {

        }
    }
    public class DimensionCMAndInch
    {
        public DimensionCM CM { get; set; }
        public DimensionInch Inch { get; set; }
        public DimensionCMAndInch()
        {
            CM = new DimensionCM();
            Inch = new DimensionInch();
        }
    }
}

