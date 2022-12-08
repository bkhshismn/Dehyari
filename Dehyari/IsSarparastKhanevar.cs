namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsSarparastKhanevar")]
    public partial class IsSarparastKhanevar
    {
        public int IsSarparastKhanevarID { get; set; }

        [Required]
        public string YesNoField { get; set; }
    }
}
