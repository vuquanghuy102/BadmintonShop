namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCE")]
    public partial class PRODUCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCE()
        {
            PRODUCTs = new HashSet<PRODUCT>();
            CATEGORies = new HashSet<CATEGORY>();
        }

        [Key]
        [StringLength(10)]
        public string PRODUCE_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCE_NAME { get; set; }

        [StringLength(300)]
        public string DESCRIPTIONS { get; set; }

        [StringLength(10)]
        public string USER_ID { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORY> CATEGORies { get; set; }
    }
}
