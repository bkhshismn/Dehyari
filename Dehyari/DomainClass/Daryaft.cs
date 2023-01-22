namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Daryaft")]
    public partial class Daryaft
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Daryaft()
        {
            DehyariHesabs = new HashSet<DehyariHesab>();
        }

        public int DaryaftID { get; set; }

        public int? NoDaryaftID { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        public double? Mablagh { get; set; }

        public virtual NoDaryaft NoDaryaft { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DehyariHesab> DehyariHesabs { get; set; }
    }
}
