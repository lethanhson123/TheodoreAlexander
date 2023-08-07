using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class StoreViewModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string CountryName { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? DateModified { get; set; }
    }
    public class DealerStoreViewModel: StoreViewModel
    {
        public List<SalesAssociateStoreForDealerInfoViewModel> Associates { get; set; }
        public List<SalesAssociateStoreForDealerInfoViewModel> PendingAssociates { get; set; }
        public List<DealerStoreForDealerInfoViewModel> Dealers { get; set; }
        public DealerStoreViewModel()
        {
            Associates = new List<SalesAssociateStoreForDealerInfoViewModel>();
            PendingAssociates = new List<SalesAssociateStoreForDealerInfoViewModel>();
            Dealers = new List<DealerStoreForDealerInfoViewModel>();
        }
    }
    public class DealerStoreForDealerInfoViewModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
    }
    public class SalesAssociateStoreForDealerInfoViewModel
    {
        public Guid SalesAssociate_ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool DealerApproved { get; set; }
    }
    public class UserStoreOnlyID
    {
        public Guid ID { get; set; }
    }
}
