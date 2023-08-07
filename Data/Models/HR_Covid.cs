using System;
namespace TA.Data.Models
{
    public partial class HR_Covid : BaseModelERP
    {       
        public int? EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public int? CovidTypeID { get; set; }
        public int? CovidLocalID { get; set; }
        public int? CovidTestID { get; set; }
        public int? CovidResultID { get; set; }
        public DateTime? CovidTestDate { get; set; }        
        public string AddressContact { get; set; }
        public string AddressContactProvince { get; set; }
        public string AddressContactDistrict { get; set; }
        public string AddressContactWard { get; set; }
        public bool? IsInjectedVaccine { get; set; }
        public bool? IsMaternityLeave { get; set; }
        public string IsolationRoom { get; set; }
        public string IsolationFloot { get; set; }
        public string IsolationArea { get; set; }
        public string IsolationName { get; set; }        
        public string IsolationAddress { get; set; }
        public DateTime? IsolationDateBegin { get; set; }
        public DateTime? IsolationDateEnd { get; set; }
        public int? IsolationProvinceID { get; set; }
        public int? IsolationDistrictID { get; set; }
        public int? IsolationWardID { get; set; }
        public string Symptom { get; set; }
    }
}

