using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class HR_EmployeeDataTransfer : HR_Employee
    {
        public DateTime? DateJoined { get; set; }
        public DateTime? DateLeft { get; set; }
        public int? DivisionID { get; set; }
        public string DivisionCode { get; set; }
        public int? StatusID { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int? BlockID { get; set; }
        public string BlockName { get; set; }
        public int? TeamID { get; set; }
        public string TeamName { get; set; }
        public int? GroupID { get; set; }
        public string GroupName { get; set; }
        public int? DutyID { get; set; }
        public string DutyCode { get; set; }
        public string DutyName { get; set; }
        public int? WorkingStatusID { get; set; }
        public string WorkingStatusName { get; set; }
    }
}
