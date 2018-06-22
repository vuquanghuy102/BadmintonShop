namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FEEDBACK")]
    public partial class FEEDBACK
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string PRODUCT_ID { get; set; }

        public int NUMBER_STAR { get; set; }

        [StringLength(200)]
        public string COMMENT { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual USER USER { get; set; }
    }
}
