using System;
using System.Linq;
using System.Collections.Generic;
using DAL;

namespace BL.DTO
{
    public class UPHFabricDTO
    {
        public string Fabric { get; set; }
        public string Content { get; set; }
        public string Sampled { get; set; }
        public int Grade { get; set; }
        public string GradeStudio { get; set; }
        public string Color { get; set; }
        public string Pattern { get; set; }
        public string VRepeat { get; set; }
        public string HRepeat { get; set; }
        public string Width { get; set; }
        public string Durability { get; set; }
        public string Application { get; set; }
        public string CleaningCode { get; set; }        
        public bool InStock { get; set; }
        public bool IsEnabledOnWeb { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsCutYardage { get; set; }
        public bool? RLC { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string GradeTrim { get; set; }
        public string CategoryTrim { get; set; }
        public string Rubs { get; set; }
        public Nullable<decimal> QtyOnHand { get; set; }
        public string UM { get; set; }        
        public bool? PFP { get; set; }       

        public static string GetContent(UPHFabric fabric)
        {
            try
            {
                List<string> strs = (new string[] { fabric.Content1, fabric.Content2, fabric.Content3, fabric.Content4, fabric.Content5, fabric.Content6 }).Where(s => !String.IsNullOrEmpty(s) && !String.IsNullOrEmpty(s.Trim())).ToList();
                return String.Join(", ", strs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Linq.Expressions.Expression<Func<DAL.UPHFabric, UPHFabricDTO>> Entity2DtoSelector = i => new UPHFabricDTO()
        {
            Fabric = i.Fabric,
            Name = i.Name,
            Application = i.Application,
            Content = i.Content1,// UPHFabricDTO.GetContent(i),
            Durability = i.Durability,
            Sampled = i.Sampled,
            Grade = i.Grade.HasValue ? i.Grade.Value : 0,
            GradeStudio = i.GradeStudio,
            Color = i.Color,
            Pattern = i.Pattern,
            VRepeat = i.VRepeat,
            HRepeat = i.HRepeat,
            Width = i.Width,
            CleaningCode = i.CleaningCode,            
            InStock = i.InStock,
            IsEnabledOnWeb = i.IsEnabledOnWeb,
            IsEnabled = i.enable,
            IsCutYardage = i.IsCutYardage,
            RLC = i.RLC,
            Category = i.Category,
            CategoryTrim = i.CategoryTrim,
            GradeTrim = i.GradeTrim,
            Rubs = i.Rubs,
            QtyOnHand = i.QtyOnHand,
            UM = i.UM,
            PFP = i.PFP,
        };
    }
    public class OriginRequestFabricObj
    {
        public string Applications { get; set; }
        public string Category { get; set; }
        public string Colors { get; set; }
        public string Patterns { get; set; }
        public string Contents { get; set; }
        public string KeyWord { get; set; }
        public bool InStock { get; set; }

        //Le Thanh Son 20210915 - Begin
        public bool PFP { get; set; }

        //Le Thanh Son 20210915 - End
    }
    public class RequestFabricObj : OriginRequestFabricObj
    {
        public int PageSize { get; set; } = 10;
        public int PageNum { get; set; } = 1;
        public string OrderBy { get; set; } = "Name";
        public bool Ascending { get; set; } = true;
    }
    public class FabricColourViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class FabricPatternViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class FabricContentViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsEnable { get; set; }
    }
    public class UpholsteryFilter
    {
        public IList<FabricColourViewModel> FabricColours { get; set; }
        public IList<FabricPatternViewModel> FabricPatterns { get; set; }
        public IList<FabricContentViewModel> FabricContents { get; set; }
        public UpholsteryFilter()
        {
            FabricColours = new List<FabricColourViewModel>();
            FabricPatterns = new List<FabricPatternViewModel>();
            FabricContents = new List<FabricContentViewModel>();
        }
    }
}