using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ViewModels
{
    public class DealerInfoViewModel
    {
        public List<DealerStoreViewModel> Stores { get; set; }
        public double PriceMultiplier { get; set; }
        public DealerInfoViewModel()
        {
            Stores = new List<DealerStoreViewModel>();
        }
    }
    public class RevokeAssociateRequestObj
    {
        [Required(ErrorMessage = "Invalid SaleId")]
        [MaxLength(254, ErrorMessage = "SaleId cannot be longer than 254 characters.")]
        public string SaleId { get; set; }

        [Required(ErrorMessage = "Invalid StoreId")]
        [MaxLength(254, ErrorMessage = "StoreId cannot be longer than 254 characters.")]
        public string StoreId { get; set; }
    }
    public class ApprovedAssociateRequestObj
    {
        [Required(ErrorMessage = "Invalid SaleId")]
        [MaxLength(254, ErrorMessage = "SaleId cannot be longer than 254 characters.")]
        public string SaleId { get; set; }

        [Required(ErrorMessage = "Invalid StoreId")]
        [MaxLength(254, ErrorMessage = "StoreId cannot be longer than 254 characters.")]
        public string StoreId { get; set; }
    }
    public class DealerSettingPageUpdateModel
    {
        public bool ChangePriceMultiplier { get; set; } = false;
        public double PriceMultiplier { get; set; }
    }
}
