namespace Badminton_Sport.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PERMISSION")]
    public partial class PERMISSION
    {
        [Key]
        [StringLength(10)]
        public string PERMISSION_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PERMISSION_NAME { get; set; }

        [StringLength(300)]
        public string DESCRIPTIONS { get; set; }

        [StringLength(50)]
        public string BUSINESS_ID { get; set; }

        public virtual BUSINESS BUSINESS { get; set; }
    }
}
