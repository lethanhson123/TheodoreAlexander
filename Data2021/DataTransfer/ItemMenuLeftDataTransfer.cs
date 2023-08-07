using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data2021.Models;

namespace TA.Data2021.DataTransfer
{
    public class ItemMenuLeftDataTransfer
    {
        public string ID { get; set; }
        public string ParentID { get; set; }
        public int? ItemCount { get; set; }
        public string Category { get; set; }
        public int? MenuFull { get; set; }
    }
}
