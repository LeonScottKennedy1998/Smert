//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smert
{
    using System;
    using System.Collections.Generic;
    
    public partial class Animals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animals()
        {
            this.OrderItems = new HashSet<OrderItems>();
        }
    
        public int animal_id { get; set; }
        public string nameA { get; set; }
        public string breed { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public int price { get; set; }
        public System.DateTime arrival_date { get; set; }
        public int id_type { get; set; }
    
        public virtual AnimalTypes AnimalTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}