using System;
using System.Collections.Generic;
using System.Linq;
using BL.DTO;
using Castle.DynamicLinqQueryBuilder;
using Newtonsoft.Json;
using BL.Dto;
using BL.BusinessService;

namespace TA_Web_2020_API._2.APIService
{
    public interface IMetadataAPIService : IDisposable
    {
        List<DesignerDto> GetAllDesigners();
        List<OptionGroupDto> GetAllOptionGroups();
        List<ItemResourceFileDto> GetAllItemResourceFiles();
        ItemResourceFileDto GetItemResourceFileByID(Guid id);
        List<ItemResourceFile_RuleDto> GetRulesByItemResourceFileID(Guid ItemResourceFileID);
        bool UpdateItemResourceFileRule(ItemResourceFile_RuleDto ruleDTO);
        Guid? AddItemResourceFileRule(ItemResourceFile_RuleDto ruleDTO);
        bool DeleteItemResourceFileRule(Guid ruleId);
        bool UpdateItemResourceFile(ItemResourceFileDto ruleDTO);
        Guid? AddItemResourceFile(ItemResourceFileDto ruleDTO);
        bool DeleteItemResourceFile(Guid id);
        List<ItemDto> FilterItemsByRule(Guid id);
        List<BrandDto> GetAllBrands();
        List<CollectionDto> GetAllCollections();
        List<LifeStyleDto> GetAllLifeStyles();
        List<StyleDto> GetAllStyles();
        List<RoomAndUsageDto> GetAllRooms();
        List<TypeDto> GetAllTypes();
    }


    public class MetadataAPIService : IMetadataAPIService
    {
        private readonly ItemBusinessService _itemService;
        private readonly RoomAndUsageBusinessService _roomService;
        private readonly TypeBusinessService _typeService;
        private readonly DesignerBusinessService _designerService;
        private readonly LifeStyleBusinessService _lifeStyleService;
        private readonly StyleBusinessService _styleService;
        private readonly CollectionBusinessService _collectionService;
        private readonly BrandBusinessService _brandService;
        private readonly OptionGroupBusinessService _optionGroupService;
        private readonly ItemResourceFileBusinessService _itemResourceFileService;
        private readonly ItemResourceFile_RuleBusinessService _itemResourceFile_RuleService;

        private bool disposed = false;
        public MetadataAPIService(DesignerBusinessService designerService, 
            OptionGroupBusinessService optionGroupService, 
            ItemResourceFileBusinessService itemResourceFileService, 
            ItemResourceFile_RuleBusinessService itemResourceFile_RuleService,
            ItemBusinessService itemService, 
            BrandBusinessService brandService, 
            CollectionBusinessService collectionService,
            LifeStyleBusinessService lifeStyleService,
            StyleBusinessService styleService,
            RoomAndUsageBusinessService roomService,
            TypeBusinessService typeService
            )
        {
            _designerService = designerService;
            _optionGroupService = optionGroupService;
            _itemResourceFileService = itemResourceFileService;
            _itemResourceFile_RuleService = itemResourceFile_RuleService;
            _itemService = itemService;
            _brandService = brandService;
            _collectionService = collectionService;
            _lifeStyleService = lifeStyleService;
            _styleService = styleService;
            _roomService = roomService;
            _typeService = typeService;
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                return;
            }
            if (disposing)
            {
                _itemService.Dispose();
                _brandService.Dispose();
                _designerService.Dispose();
                _optionGroupService.Dispose();
                _itemResourceFileService.Dispose();
                _itemResourceFile_RuleService.Dispose();
                _collectionService.Dispose();
                _lifeStyleService.Dispose();
                _styleService.Dispose();
                _typeService.Dispose();
                _roomService.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<TypeDto> GetAllTypes()
        {
            try
            {
                return this._typeService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoomAndUsageDto> GetAllRooms()
        {
            try
            {
                return this._roomService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<StyleDto> GetAllStyles()
        {
            try
            {
                return this._styleService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LifeStyleDto> GetAllLifeStyles()
        {
            try
            {
                return this._lifeStyleService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CollectionDto> GetAllCollections()
        {
            try
            {
                return this._collectionService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BrandDto> GetAllBrands()
        {
            try
            {
                return _brandService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DesignerDto> GetAllDesigners()
        {
            try
            {
                return this._designerService.Get().OrderBy(i => i.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OptionGroupDto> GetAllOptionGroups()
        {
            try
            {
                return this._optionGroupService.Get().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemResourceFileDto> GetAllItemResourceFiles()
        {
            try
            {
                return this._itemResourceFileService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItemResourceFileDto GetItemResourceFileByID(Guid id)
        {
            try
            {
                return this._itemResourceFileService.GetByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemResourceFile_RuleDto> GetRulesByItemResourceFileID(Guid ItemResourceFileID)
        {
            try
            {
                return this._itemResourceFile_RuleService.GetRulesByItemResourceFileID(ItemResourceFileID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateItemResourceFileRule(ItemResourceFile_RuleDto ruleDTO)
        {
            try
            {
                ruleDTO.ModifiedDate = System.DateTime.UtcNow;
                return _itemResourceFile_RuleService.Update(ruleDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid? AddItemResourceFileRule(ItemResourceFile_RuleDto ruleDTO)
        {
            try
            {
                ruleDTO.ModifiedDate = System.DateTime.UtcNow;
                return _itemResourceFile_RuleService.Add(ruleDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteItemResourceFileRule(Guid ruleId)
        {
            try
            {
                return _itemResourceFile_RuleService.Delete(ruleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateItemResourceFile(ItemResourceFileDto dto)
        {
            try
            {
                dto.ModifiedDate = System.DateTime.UtcNow;
                return _itemResourceFileService.Update(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid? AddItemResourceFile(ItemResourceFileDto dto)
        {
            try
            {
                dto.ModifiedDate = System.DateTime.UtcNow;
                return _itemResourceFileService.Add(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteItemResourceFile(Guid id)
        {
            try
            {
                return _itemResourceFileService.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemDto> FilterItemsByRule(Guid ruleId)
        {
            try
            {
                ItemResourceFile_RuleDto rule = this._itemResourceFile_RuleService.GetRuleByItemResourceFileRuleID(ruleId);
                QueryBuilderFilterRule ruleQuery = TAQueryBuilderFilterRule.ConvertToQueryBuilderFilterRuleFromJsonRule(rule.Rule);
                List<ItemDto> ret = _itemService.FilterItemByRule(ruleQuery).ToList();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemDto> FilterItemsByRule(ItemResourceFile_RuleDto rule)
        {
            return new List<ItemDto>();
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class TAQueryBuilderFilterRule
        {
            [JsonProperty("Condition")]
            public string Condition { get; set; }

            [JsonProperty("Field")]
            public string Field { get; set; }

            [JsonProperty("Id")]
            public string Id { get; set; }

            [JsonProperty("Input")]
            public string Input { get; set; }

            [JsonProperty("Operator")]
            public string Operator { get; set; }

            [JsonProperty("Rules")]
            public List<TAQueryBuilderFilterRule> Rules { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }

            [JsonProperty("Value")]
            public string Value { get; set; }

            [JsonProperty("Entity")]
            public string Entity { get; set; }

            private QueryBuilderFilterRule ConvertToQueryBuilderFilterRule()
            {
                QueryBuilderFilterRule queryBuilderFilterRule = new QueryBuilderFilterRule();
                queryBuilderFilterRule.Condition = this.Condition;
                queryBuilderFilterRule.Id = this.Id;
                queryBuilderFilterRule.Input = this.Input;
                queryBuilderFilterRule.Operator = this.Operator;
                queryBuilderFilterRule.Value = new[] { this.Value };
                if (!String.IsNullOrEmpty(this.Field))
                {
                    queryBuilderFilterRule.Field = this.Field.Split('0')[0] ?? null;
                    queryBuilderFilterRule.Type = this.Field.Split('0')[1] ?? null;
                }
                if (this.Rules != null)
                {
                    queryBuilderFilterRule.Rules = this.Rules.Select(r => r.ConvertToQueryBuilderFilterRule()).ToList();
                }
                return queryBuilderFilterRule;
            }

            public static QueryBuilderFilterRule ConvertToQueryBuilderFilterRuleFromJsonRule(string jsonRule)
            {
                TAQueryBuilderFilterRule ruleWrapper = JsonConvert.DeserializeObject<TAQueryBuilderFilterRule>(jsonRule);
                QueryBuilderFilterRule ruleQuery = ruleWrapper.ConvertToQueryBuilderFilterRule();
                return ruleQuery;
            }
        }
    }
}