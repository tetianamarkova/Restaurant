namespace Kodisoft.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tables
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tables()
        {
            Places = new HashSet<Places>();
        }

        [Key]
        public int TableId { get; set; }

        [Required]
        [StringLength(100)]
        public string TableName { get; set; }

        public bool? TableStatus { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        [Required]
        [StringLength(100)]
        public string ImagePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Places> Places { get; set; }
    }
}
