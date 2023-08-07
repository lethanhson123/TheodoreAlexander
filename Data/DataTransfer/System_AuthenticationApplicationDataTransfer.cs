using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class System_AuthenticationApplicationDataTransfer : System_AuthenticationApplication
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ApplicationName { get; set; }        
    }
}
