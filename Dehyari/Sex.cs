namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sex")]
    public partial class Sex
    {
        public int SexID { get; set; }

        [Column("Sex")]
        [StringLength(20)]
        public string Sex1 { get; set; }
    }
}
