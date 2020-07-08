using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
    public class Rating:IdentityBase
    {

 
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
    }
}
