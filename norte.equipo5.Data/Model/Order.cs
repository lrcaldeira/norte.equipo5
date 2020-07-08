using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
    public class Order:IdentityBase
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int OrderNumber { get; set; }
        public int ItemCount { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
