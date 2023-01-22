namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zamin")]
    public partial class Zamin
    {
        public int ZaminID { get; set; }

        public double? Masahat { get; set; }

        public int? NoZaminID { get; set; }

        public int? JaygahZaminID { get; set; }

        public int? PersonID { get; set; }

        public virtual JaygahZamin JaygahZamin { get; set; }

        public virtual NoZamin NoZamin { get; set; }

        public virtual Person Person { get; set; }
    }
}
