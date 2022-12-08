namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsKhanedar")]
    public partial class IsKhanedar
    {
        public int IsKhanedarID { get; set; }

        [Required]
        public string YesNoField { get; set; }
    }
}
