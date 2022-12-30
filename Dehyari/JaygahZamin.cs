namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JaygahZamin")]
    public partial class JaygahZamin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JaygahZamin()
        {
            Zamins = new HashSet<Zamin>();
        }

        public int JaygahZaminID { get; set; }

        [Column("JaygahZamin")]
        [StringLength(50)]
        public string JaygahZamin1 { get; set; }
        public Int64 NerkhAb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamin> Zamins { get; set; }
    }
}
