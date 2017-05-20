using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Models.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactFacebook { get; set; }
        public string ContactSkype { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMobile { get; set; }
        public bool Status { get; set; }
        public string Department { get; set; }
    }
}
