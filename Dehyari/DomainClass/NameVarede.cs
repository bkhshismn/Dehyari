namespace Dehyari
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NameVarede")]
    public partial class NameVarede
    {
        public int NameVaredeID { get; set; }

        public int? OnvanID { get; set; }

        [StringLength(200)]
        public string Ferestande { get; set; }

        public byte[] Tasvir { get; set; }

        [StringLength(20)]
        public string Date { get; set; }

        [StringLength(20)]
        public string ShmareName { get; set; }

        public int? PersonID { get; set; }

        public virtual OnvanName OnvanName { get; set; }
    }
}
