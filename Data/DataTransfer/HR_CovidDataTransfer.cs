using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class HR_CovidDataTransfer : HR_Covid
    {       
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CovidLocalName { get; set; }
        public string CovidResultName { get; set; }
        public string CovidTestName { get; set; }
        public string CovidTypeName { get; set; }      
    }
}
