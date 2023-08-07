using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityService
{
    public class ItemResourceFileEntityService : ITAWEntityService<ItemResourceFile, Guid>
    {

        public ItemResourceFileEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override IQueryable<ItemResourceFile> Get()
        {
            return _ctx.ItemResourceFiles.AsNoTracking();
        }


        public override IQueryable<ItemResourceFile> Get(Guid id)
        {
            return _ctx.ItemResourceFiles.AsNoTracking().Where(i => i.ID == id);
        }

        public override bool Update(ItemResourceFile rule)
        {
            try
            {
                _ctx.Entry(rule).State = EntityState.Modified;
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override bool Add(ItemResourceFile rule)
        {
            try
            {
                _ctx.ItemResourceFiles.Add(rule);
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(Guid id)
        {
            try
            {
                ItemResourceFile item = _ctx.ItemResourceFiles.Where(i => i.ID == id).FirstOrDefault();
                if (item != null)
                {
                    _ctx.ItemResourceFiles.Remove(item);
                    return _ctx.SaveChanges() > 0;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
