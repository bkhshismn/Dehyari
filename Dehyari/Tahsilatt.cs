namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tahsilatt")]
    public partial class Tahsilatt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TahsilatID { get; set; }

        [StringLength(20)]
        public string NoTahsilat { get; set; }
    }
}
