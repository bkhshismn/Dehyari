namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BedNo")]
    public partial class BedNo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BedNo()
        {
            PersonHesabs = new HashSet<PersonHesab>();
        }

        public int BedNoID { get; set; }

        [Column("BedNoTitle")]
        [StringLength(50)]
        public string BedNo1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonHesab> PersonHesabs { get; set; }
    }
}
