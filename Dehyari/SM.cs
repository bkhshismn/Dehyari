namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SMS")]
    public partial class SM
    {
        [Key]
        public int SmsID { get; set; }

        [StringLength(200)]
        public string Onvan { get; set; }

        public string Matn { get; set; }

        public int? DeliveryID { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        public int? PesronID { get; set; }

        public virtual Delivery Delivery { get; set; }
    }
}
