using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EntityService
{
    public class UPHFabricEntityService:ITAWEntityService<UPHContent, int>
    {
        public UPHFabricEntityService(TheodoreAlexanderEntities ctx):base(ctx)
        {
            
        }

        public IQueryable<UPHContent> GetFabricContent()
        {
            return _ctx.UPHContents.AsNoTracking().Where(c => c.IsEnable == true);
        }

        public IQueryable<UPHColour> GetFabricColour()
        {
            return _ctx.UPHColours.AsNoTracking().Where(c => c.enable == true);
        }

        public IQueryable<UPHPattern> GetFabricPattern()
        {
            return _ctx.UPHPatterns.AsNoTracking().Where(p => p.enable == true);
        }

        public IQueryable<UPHFabric> GetUPHByKeyword(IQueryable<UPHFabric> fabrics, string keyWord = null)
        {
            if (!String.IsNullOrEmpty(keyWord))
            {
                string cleanWord = keyWord.Trim().ToLower();
                fabrics = fabrics.Where(o => o.Fabric.ToLower().Contains(cleanWord) || o.Name.ToLower().Contains(cleanWord) || o.Content1.ToLower().Contains(cleanWord)
                || o.Content2.ToLower().Contains(cleanWord) || o.Content3.ToLower().Contains(cleanWord) || o.Content4.ToLower().Contains(cleanWord) || o.Content5.ToLower().Contains(cleanWord)
                || o.Content6.ToLower().Contains(cleanWord) || o.Sampled.ToLower().Contains(cleanWord) || o.Color.ToLower().Contains(cleanWord) || o.Pattern.ToLower().Contains(cleanWord)
                || o.ColorCode.ToLower().Contains(cleanWord) || o.PatternCode.ToLower().Contains(cleanWord) || o.CategoryTrim.ToLower().Contains(cleanWord));
            }
            return fabrics;
        }

        public IQueryable<UPHFabric> GetUPHs()
        {
            return _ctx.UPHFabrics.AsNoTracking().Where(f=>f.enable.Value == true && f.IsEnabledOnWeb == true).OrderBy(f=>f.Name);            
        }

        public IQueryable<UPHFabric> GetActiveFabrics()
        {
            return _ctx.UPHFabrics.AsNoTracking().Where(f => f.enable.Value == true);
        }
        //Le Thanh Son 20210915 - Begin
        public IQueryable<UPHFabric> GetUPHsByPFP(IQueryable<UPHFabric> fabrics, bool PFP)
        {
            return fabrics.Where(f => f.PFP == PFP);
        }
        //Le Thanh Son 20210915 - End
        public IQueryable<UPHFabric> GetUPHsByInStock(IQueryable<UPHFabric> fabrics, bool inStock)
        {
            return fabrics.Where(f => f.InStock == inStock);
        }

        public IQueryable<UPHFabric> GetUPHsByColor(IQueryable<UPHFabric> fabrics, IList<string> lstColor)
        {
            return fabrics.Where(f => lstColor.Any(l => l.ToUpper() ==  f.Color.ToUpper()));
        }

        public IQueryable<UPHFabric> GetUPHsByPattern(IQueryable<UPHFabric> fabrics, IList<string> lstPattern)
        {
            return fabrics.Where(f => lstPattern.Any(l => l.ToUpper() == f.Pattern.ToUpper()));
        }

        public IQueryable<UPHFabric> GetUPHsByContent(IQueryable<UPHFabric> fabrics, IList<string> lstContent)
        {
            return fabrics.Where(f => lstContent.Any(l => 
            f.Content1.ToUpper().Contains(l.ToUpper())
            || f.Content1.ToUpper().Contains(l.ToUpper())
            || f.Content2.ToUpper().Contains(l.ToUpper())
            || f.Content3.ToUpper().Contains(l.ToUpper())
            || f.Content4.ToUpper().Contains(l.ToUpper())
            || f.Content5.ToUpper().Contains(l.ToUpper())
            || f.Content6.ToUpper().Contains(l.ToUpper())
            ));
        }

        public override IQueryable<UPHContent> Get()
        {
            throw new NotImplementedException();
        }

        public override IQueryable<UPHContent> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Add(UPHContent t)
        {
            throw new NotImplementedException();
        }

        public override bool Update(UPHContent t)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
