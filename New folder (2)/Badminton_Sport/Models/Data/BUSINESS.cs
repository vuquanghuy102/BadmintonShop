namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BUSINESS")]
    public partial class BUSINESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BUSINESS()
        {
            PERMISSIONs = new HashSet<PERMISSION>();
        }

        [Key]
        [StringLength(50)]
        public string BUSINESS_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string BUSINESS_NAME { get; set; }

        [StringLength(300)]
        public string DESCRIPTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMISSION> PERMISSIONs { get; set; }
    }
}
