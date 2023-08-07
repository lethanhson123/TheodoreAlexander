using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TA.Data.Models;

namespace TA.Data.DataTransfer
{
    public partial class EMMA
    {
        public string email { get; set; }
        public List<string> group_ids { get; set; }
        public string signup_form_id { get; set; }
        public bool opt_in_confirmation { get; set; }
    }
}
