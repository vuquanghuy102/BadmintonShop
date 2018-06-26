namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILL")]
    public partial class BILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILL()
        {
            BILL_DETAIL = new HashSet<BILL_DETAIL>();
        }

        [Key]
        [StringLength(10)]
        public string BILL_ID { get; set; }

        [StringLength(10)]
        public string USER_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATE_BUY { get; set; }

        [StringLength(10)]
        public string APPROVAL_ADMIN { get; set; }

        public bool STT { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL_DETAIL> BILL_DETAIL { get; set; }
    }
}
