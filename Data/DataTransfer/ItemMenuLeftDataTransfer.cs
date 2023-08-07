using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public class ItemMenuLeftDataTransfer
    {
        public string ID { get; set; }
        public int? ItemCount { get; set; }
        public string Category { get; set; }
        public int? MenuFull { get; set; }
    }
}
