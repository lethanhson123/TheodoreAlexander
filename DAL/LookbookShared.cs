//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class LookbookShared
    {
        public System.Guid ID { get; set; }
        public System.Guid FromUser_ID { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public System.Guid Lookbook_ID { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string Message { get; set; }
        public bool IncludeNotes { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Lookbook Lookbook { get; set; }
        public virtual User User { get; set; }
    }
}
