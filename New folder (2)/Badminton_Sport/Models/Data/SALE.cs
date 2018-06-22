namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALE")]
    public partial class SALE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALE()
        {
            PRODUCTs = new HashSet<PRODUCT>();
        }

        [Key]
        [StringLength(10)]
        public string SALE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string SALE_NAME { get; set; }

        [StringLength(500)]
        public string DESCRIPSION { get; set; }

        public int? SALE_PRICENT { get; set; }

        [StringLength(10)]
        public string USER_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }

        public virtual USER USER { get; set; }
    }
}
