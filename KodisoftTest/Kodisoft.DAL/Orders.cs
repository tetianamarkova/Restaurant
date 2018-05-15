namespace Kodisoft.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStatus { get; set; }

        public double OrderTips { get; set; }

        public int OrderPlaceId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItem { get; set; }

        public virtual Places Places { get; set; }

        public virtual StatusList StatusList { get; set; }
    }
}
