using System.ComponentModel.DataAnnotations;

namespace DAL.ViewModels
{
    public class UserSettingViewModel
    {
        [Required(ErrorMessage = "Invalid ShowSKUs")]
        public bool ShowSKUs { get; set; }

        [Required(ErrorMessage = "Invalid ShowPrice")]
        public bool ShowPrice { get; set; }

        [Required(ErrorMessage = "Invalid ShowPrice")]
        public bool ShowAddress { get; set; }

        [Required(ErrorMessage = "Invalid ShowWholesalePrice")]
        public bool ShowWholesalePrice { get; set; }

        [Required(ErrorMessage = "Invalid Price Multiplier")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter Price Multiplier value bigger than {0}")]
        public double RetailMultiplier { get; set; }
    }
}
