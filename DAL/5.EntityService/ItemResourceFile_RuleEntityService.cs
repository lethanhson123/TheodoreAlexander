using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EntityService
{
    public class ItemResourceFile_RuleEntityService : ITAWEntityService<ItemResourceFile_Rule, Guid>
    {

        public ItemResourceFile_RuleEntityService(TheodoreAlexanderEntities ctx) : base(ctx)
        {

        }

        public override IQueryable<ItemResourceFile_Rule> Get()
        {
            return _ctx.ItemResourceFile_Rule.AsNoTracking();
        }

        public IQueryable<ItemResourceFile_Rule> GetRulesByItemResourceFileID(Guid id)
        {
            return Get().Where(i => i.ItemResourceFile_ID == id);
        }

        public override IQueryable<ItemResourceFile_Rule> Get(Guid id)
        {
            return Get().Where(i => i.ID == id);
        }

        public override bool Update(ItemResourceFile_Rule rule) {
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
        public override bool Add(ItemResourceFile_Rule rule)
        {
            try
            {
                _ctx.ItemResourceFile_Rule.Add(rule);
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
                ItemResourceFile_Rule rule = _ctx.ItemResourceFile_Rule.Where(i => i.ID == id).FirstOrDefault();
                if (rule != null)
                {
                    _ctx.ItemResourceFile_Rule.Remove(rule);
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

        //public override IQueryable<ItemResourceFile_Rule> Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public override ItemResourceFile_Rule Get(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
