namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsMarried")]
    public partial class IsMarried
    {
        public int IsMarriedID { get; set; }

        [Required]
        public string Married { get; set; }
    }
}
