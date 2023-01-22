namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoDaryaft")]
    public partial class NoDaryaft
    {
        public int NoDaryaftID { get; set; }

        [Column("NoDaryaft")]
        [StringLength(500)]
        public string NoDaryaft1 { get; set; }

        public virtual Daryaft Daryaft { get; set; }
    }
}
