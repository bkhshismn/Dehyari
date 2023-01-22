namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bime")]
    public partial class Bime
    {
        public int BimeID { get; set; }

        [StringLength(20)]
        public string NoBime { get; set; }
    }
}
