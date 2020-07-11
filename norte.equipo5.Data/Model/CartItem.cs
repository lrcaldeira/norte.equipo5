using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
    public class CartItem:IdentityBase
    {
   
  
        public int CartId { get; set; }
        
        public int ProductId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public virtual Cart cart { get; set; }


    }
}
