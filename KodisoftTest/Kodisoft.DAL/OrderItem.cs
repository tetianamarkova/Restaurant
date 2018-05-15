namespace Kodisoft.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }

        public int ItemId { get; set; }

        public int ItemAmount { get; set; }

        public int OrderId { get; set; }

        public virtual MenuItems MenuItems { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
