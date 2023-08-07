using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class TypeDataTransfer : TA.Data.Models.Type
    {
        public string RoomAndUsageName { get; set; }            
    }
}
