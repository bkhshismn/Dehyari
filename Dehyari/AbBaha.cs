namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AbBaha")]
    public partial class AbBaha
    {
        public int AbBahaID { get; set; }

        public int? Sal { get; set; }

        public double? Mablagh { get; set; }
    }
}
