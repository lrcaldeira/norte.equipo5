using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
   public class Product: IdentityBase
    {
        public Product()
        {
            Image = "empty.png";

        }
        [Required]
        [DisplayName("Titulo")]
        public string Title { get; set;}

        [Required]
        [DisplayName("Descripción")]
        public string Description { get; set;}

        [Required]
        [DisplayName("Id Artista")]
        public int ArtistId { get; set;}

        [DisplayName("Imagen")]
        public string Image { get; set;}

        [DisplayName("Precio")]
        public double Price { get; set;}

        [DisplayName("Cantidad Vendidos")]
        public int QuantitySold { get; set;}

        [DisplayName("Calificación Promedio")]
        public double AvgStars { get; set; }

        public virtual Artist Artist { get; set; } //el artista que es el producto//
    }
}
