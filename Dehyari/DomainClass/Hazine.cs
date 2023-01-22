namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hazine")]
    public partial class Hazine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hazine()
        {
            DehyariHesabs = new HashSet<DehyariHesab>();
        }

        public int HazineID { get; set; }

        public int? NoHazineID { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        public double? Mablagh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DehyariHesab> DehyariHesabs { get; set; }

        public virtual NoHazine NoHazine { get; set; }
    }
}
