namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            PRODUCTs = new HashSet<PRODUCT>();
            PRODUCEs = new HashSet<PRODUCE>();
        }

        [Key]
        [StringLength(10)]
        public string CATEGORY_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CATEGORY_NAME { get; set; }

        [StringLength(10)]
        public string USER_ID { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCE> PRODUCEs { get; set; }
    }
}
