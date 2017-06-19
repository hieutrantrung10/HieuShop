using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Models.Models
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }

        [Key, Column(Order = 1)]
        public string TagID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}
