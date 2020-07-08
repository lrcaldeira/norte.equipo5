using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
    public class OrderDetail:IdentityBase
    {

  
        public int OrderId { get; set; }

       
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

     }
}
