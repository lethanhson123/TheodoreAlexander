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
    
    public partial class ItemResourceFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemResourceFile()
        {
            this.ItemResourceFile_Rule = new HashSet<ItemResourceFile_Rule>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string URL { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Property { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemResourceFile_Rule> ItemResourceFile_Rule { get; set; }
    }
}
