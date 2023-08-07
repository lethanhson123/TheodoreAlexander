using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class HR_EmployeeDataTransfer001
    {
        public int? ID { get; set; }       
        public string FullName { get; set; }
    }
}
