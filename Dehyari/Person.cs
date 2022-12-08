namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            NameSaderes = new HashSet<NameSadere>();
            PersonHesabs = new HashSet<PersonHesab>();
            Zamins = new HashSet<Zamin>();
        }

        public int PersonID { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Family { get; set; }

        public int? SexID { get; set; }

        [StringLength(10)]
        public string CodeMelli { get; set; }

        [StringLength(10)]
        public string ShomareShenasname { get; set; }

        [StringLength(20)]
        public string TarikhTavalod { get; set; }

        [StringLength(60)]
        public string NamePedar { get; set; }

        [StringLength(11)]
        public string TelSabet { get; set; }

        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(10)]
        public string CodePosti { get; set; }

        public int? BimeID { get; set; }

        public int TahsilatID { get; set; }

        public double? MetrajKhane { get; set; }

        public int? IsKhanedarID { get; set; }

        public int? IsSarparastKhanevarID { get; set; }

        public int? IsMarriedID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NameSadere> NameSaderes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonHesab> PersonHesabs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamin> Zamins { get; set; }
    }
}
