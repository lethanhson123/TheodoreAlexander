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
    
    public partial class Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type()
        {
            this.Items = new HashSet<Item>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> RoomAndUsage_ID { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<bool> IsEnabledOnWeb { get; set; }
        public string WebURL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
        public virtual RoomAndUsage RoomAndUsage { get; set; }
    }
}
