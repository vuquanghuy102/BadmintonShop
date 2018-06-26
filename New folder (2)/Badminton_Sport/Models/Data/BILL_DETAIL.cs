namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BILL_DETAIL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BILL_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string PRODUCT_ID { get; set; }

        public int QUANTITY { get; set; }

        public double TOTAL { get; set; }

        public virtual BILL BILL { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
