using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class MenuRequestObj
    {
        [Required]
        public string XmlPath { get; set; }
    }
}
