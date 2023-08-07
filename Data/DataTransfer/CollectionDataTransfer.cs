using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class CollectionDataTransfer : Collection
    {
        public string BrandName { get; set; }            
    }
}
