namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            BILL_DETAIL = new HashSet<BILL_DETAIL>();
            FEEDBACKs = new HashSet<FEEDBACK>();
        }

        [Key]
        [StringLength(10)]
        public string PRODUCT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PRODUCT_NAME { get; set; }

        public int? SIZE { get; set; }

        public double PRICE { get; set; }

        public int? NUMBERSOLD { get; set; }

        public int? EXISTENCE { get; set; }

        [StringLength(257)]
        public string IMAGES { get; set; }

        [StringLength(500)]
        public string DESCRIPSION { get; set; }

        public bool? VISIABLE { get; set; }

        public bool? ISNEW { get; set; }

        [StringLength(10)]
        public string SALEID { get; set; }

        [StringLength(10)]
        public string PRODUCE_ID { get; set; }

        [StringLength(10)]
        public string CATEGORY_ID { get; set; }

        [StringLength(10)]
        public string USER_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL_DETAIL> BILL_DETAIL { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK> FEEDBACKs { get; set; }

        public virtual PRODUCE PRODUCE { get; set; }

        public virtual SALE SALE { get; set; }

        public virtual USER USER { get; set; }
    }
}
