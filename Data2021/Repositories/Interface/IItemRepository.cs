using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TA.Data2021.DataTransfer;
using TA.Data2021.Models;

namespace TA.Data2021.Repositories
{
    public interface IItemRepository : IRepository<Item>
    {
        TA.Data2021.Models.Item GetByID(string ID);
        TA.Data2021.Models.Item GetBySKU(string SKU);
        TA.Data2021.Models.Item GetByURLCode(string URLCode);
        List<TA.Data2021.Models.Item> GetByIsActiveToList(bool isActive);
        List<ItemDataTransfer> GetDataTransferByIsActiveAndIsActiveTAUSToList(bool isActive, bool isActiveTAUS);
        List<ItemDataTransfer> GetDataTransferByIsActiveTAUSAndExtendingToList(bool isActiveTAUS, bool extending);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked);
        List<ItemDataTransfer> GetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked);
        int GetByIsActiveTAUSAndExtendingToItemCount(bool isActiveTAUS, bool extending);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndType_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string type_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndShape_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string shape_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndRoomAndUsage_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string roomAndUsage_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndLifeStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string lifeStyle_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndStyle_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string style_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCollection_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string collection_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndBrand_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string brand_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndExtendingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool extending, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndSearchStringAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string searchString, bool inStockProgram, bool isStocked);
        Task<int> AsyncGetByIsActiveTAUSAndExtendingToItemCount(bool isActiveTAUS, bool extending);        
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndCasualLivingAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndIsCFPItemAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, bool isCFPItem, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndOptionGroup2_IDAndInStockProgramAndIsStockedToList(string user_ID, bool isActiveTAUS, string optionGroup2_ID, bool inStockProgram, bool isStocked);
        Task<List<ItemDataTransfer001>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew);
        Task<List<ItemDataTransfer001>> AsyncGetDataTransferByUser_IDAndIsActiveTAUSAndTailorFitProgramToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem, bool isNew);
        Task<List<ItemMenuLeftDataTransfer>> AsyncGetItemMenuLeftDataTransferByUser_IDAndIsActiveTAUSAndFiltersToList(string user_ID, bool isActiveTAUS, string room_IDList, string brand_IDList, string type_IDList, string shape_IDList, string style_IDList, string lifeStyle_IDList, string collection_IDList, string designer_IDList, string searchString, bool extending, bool isStocked, bool isCFPItem);
        int UpdateItemsImageCount();
        int UpdateItemsURLCode();
        int UpdateItemsDescription();
        int UpdateBySQL(Item model);
        Task<int> AsyncUpdateItemsImageCount();
        List<Item> GetWithImageIsNullToList();
        List<Item> GetByIDListToList(string IDList);
    }
}
