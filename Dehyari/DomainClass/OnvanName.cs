namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OnvanName")]
    public partial class OnvanName
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OnvanName()
        {
            NameSaderes = new HashSet<NameSadere>();
            NameVaredes = new HashSet<NameVarede>();
        }

        [Key]
        public int OnvanID { get; set; }

        [StringLength(500)]
        public string Onvan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NameSadere> NameSaderes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NameVarede> NameVaredes { get; set; }
    }
}
