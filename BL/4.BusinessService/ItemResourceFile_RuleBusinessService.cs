using System;
using System.Linq;
using BL.EntityService;
using BL.DTO;
using System.Collections.Generic;
using DAL;
using DAL.EntityService;

namespace BL.BusinessService
{
    public class ItemResourceFile_RuleBusinessService
    {
        private bool disposed = false;
        private readonly ItemResourceFile_RuleEntityService _itemResourceFileRuleModelService;

        public ItemResourceFile_RuleBusinessService(ItemResourceFile_RuleEntityService itemResourceFileRuleModelService)
        {
            _itemResourceFileRuleModelService = itemResourceFileRuleModelService;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemResourceFileRuleModelService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<ItemResourceFile_RuleDto> GetAll()
        {
            try
            {
                var ret = _itemResourceFileRuleModelService.Get().Select(e => new ItemResourceFile_RuleDto()
                {
                    ID = e.ID,
                    IsEnabled = e.IsEnabled,
                    Title = e.Title,
                    Description = e.Description,
                    ItemResourceFile_ID = e.ItemResourceFile_ID,
                    Rule = e.Rule,
                    Region = e.Region,
                    ModifiedBy = e.ModifiedBy,
                    ModifiedDate = e.ModifiedDate
                }).OrderByDescending(e => e.ModifiedDate).ToList();
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ItemResourceFile_RuleDto> GetRulesByItemResourceFileID(Guid id)
        {
            return _itemResourceFileRuleModelService.GetRulesByItemResourceFileID(id).Select(e => new ItemResourceFile_RuleDto()
            {
                ID = e.ID,
                IsEnabled = e.IsEnabled,
                Title = e.Title,
                Description = e.Description,
                ItemResourceFile_ID = e.ItemResourceFile_ID,
                Rule = e.Rule,
                Region = e.Region,
                ModifiedBy = e.ModifiedBy,
                ModifiedDate = e.ModifiedDate
            }).ToList();
        }

        public ItemResourceFile_RuleDto GetRuleByItemResourceFileRuleID(Guid id) {
            try
            {
                ItemResourceFile_RuleDto rule = _itemResourceFileRuleModelService.Get(id).Select(r => new ItemResourceFile_RuleDto() {
                    ID = r.ID,
                    IsEnabled = r.IsEnabled,
                    Title = r.Title,
                    Description = r.Description,
                    ItemResourceFile_ID = r.ItemResourceFile_ID,
                    Rule = r.Rule,
                    Region = r.Region,
                    ModifiedBy = r.ModifiedBy,
                    ModifiedDate = r.ModifiedDate
                }).FirstOrDefault();
                return rule;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ItemResourceFile_RuleDto ruleDTO)
        {
            try
            {
                ItemResourceFile_Rule rule = _itemResourceFileRuleModelService.Get(ruleDTO.ID).FirstOrDefault();
                if (rule != null)
                {
                    rule.Description = ruleDTO.Description;
                    rule.IsEnabled = ruleDTO.IsEnabled;
                    rule.Rule = ruleDTO.Rule;
                    rule.Region = ruleDTO.Region;
                    rule.Title = ruleDTO.Title;
                    rule.ModifiedBy = ruleDTO.ModifiedBy;
                    rule.ModifiedDate = ruleDTO.ModifiedDate;
                    return _itemResourceFileRuleModelService.Update(rule);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public Guid? Add(ItemResourceFile_RuleDto ruleDTO)
        {
            try
            {
                ItemResourceFile_Rule rule = new ItemResourceFile_Rule()
                {
                    ID = Guid.NewGuid(),
                    Description = ruleDTO.Description,
                    IsEnabled = ruleDTO.IsEnabled,
                    Rule = ruleDTO.Rule,
                    Region = ruleDTO.Region,
                    Title = ruleDTO.Title,
                    ModifiedBy = ruleDTO.ModifiedBy,
                    ModifiedDate = ruleDTO.ModifiedDate,
                    ItemResourceFile_ID = ruleDTO.ItemResourceFile_ID
                };
                if (_itemResourceFileRuleModelService.Add(rule))
                {
                    return rule.ID;
                }
                else {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid ruleId)
        {
            try
            {
                return _itemResourceFileRuleModelService.Delete(ruleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}