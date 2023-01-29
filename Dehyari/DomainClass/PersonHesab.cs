namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonHesab")]
    public partial class PersonHesab
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HesabID { get; set; }

        public int SaleMali { get; set; }

        public double? Bed { get; set; }

        public double? Bes { get; set; }

        public int? BedNoID { get; set; }

        public int? PersonID { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        public virtual BedNo BedNo { get; set; }

        public virtual Person Person { get; set; }
        [StringLength(100)]
        public string Sayer { get; set; }
    }
}
