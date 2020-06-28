using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
    public class Cart:IdentityBase
    {

        public Cart()
        {
            this.CartItems = new HashSet<CartItem>();
        }

        public string Cookie { get; set; }
        public DateTime CartDate { get; set; }
        public int ItemCount { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
