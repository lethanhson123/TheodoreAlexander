using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class LocatorViewModel:SearchStore
    {
        public StoreCoordinateViewModel StoreCoordinate { get; set; }
        public bool IsPreferred { get; set; }
        public bool IsAlthorpLivingHistory { get; set; }
        public bool IsAlexaHampton { get; set; }
        public bool IsUpholstery { get; set; }
        public bool IsTAStudio { get; set; }
        public bool IsSalone { get; set; }
        public bool IsRalphLauren { get; set; }
        public Guid CityId { get; set; }
    }
    public class StoreCoordinateViewModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public string GoogleAddress { get; set; }
        public string GoogleURL { get; set; }
    }
    public class RequestStoreObj
    {
        public string KeySearch { get; set; }
    }
    public class PaginationRequestStoreObj: RequestStoreObj
    {
        public int PageSize { get; set; } = 10;
        public int PageNum { get; set; } = 1;
        public string OrderBy { get; set; } = "IsPreferred";
        public bool Ascending { get; set; } = true;
    }
}
