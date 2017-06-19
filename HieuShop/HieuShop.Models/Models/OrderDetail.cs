using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HieuShop.Models.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key,Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        [DefaultValue(0)]
        public int Quantity { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
