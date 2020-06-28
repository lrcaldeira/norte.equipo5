using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
   public class IdentityBase //valores globales para todos//
    {
        [Key] //esta propriedad va a ser clave//
        public int Id { get; set; } 
        [Required]

        public DateTime CreatedOn { get; set; } //fecha de creacion//
        public string CreatedBy { get; set;} //creado por //
        [Required]

        public DateTime ChangedOn { get; set; }


        public string ChangedBy { get; set; }
    }
}
