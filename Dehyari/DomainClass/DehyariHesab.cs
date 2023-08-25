namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DehyariHesab")]
    public partial class DehyariHesab
    {
        public int DehyariHesabID { get; set; }

        public double? Bed { get; set; }

        public double? Bes { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        public int? HazineID { get; set; }

        public int? DaryaftID { get; set; }

        public int? PersonHesabID { get; set; }

        public virtual Daryaft Daryaft { get; set; }

        public virtual Hazine Hazine { get; set; }

        public virtual PersonHesab PersonHesab { get; set; }
    }
}
