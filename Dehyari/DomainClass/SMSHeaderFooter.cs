using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dehyari.DomainClass
{
    [Table( "SMSHeaderFooter")]
    public partial class SMSHeaderFooter
    {
        public int ID { get; set; }
        [StringLength(maximumLength:500)]
        public string Header { get; set; }
        [StringLength(maximumLength:500)]
        public string Footer { get; set; }
    }
}
