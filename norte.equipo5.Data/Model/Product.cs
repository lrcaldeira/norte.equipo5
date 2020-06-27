﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Model
{
   public class Product: IdentityBase
    {
        public string Title { get; set;}
        public string Description { get; set;}
        public int ArtistId { get; set;}
        public string Image { get; set;}
        public double Price { get; set;}
        public int QuantitySold { get; set;}
        public double AvgStars { get; set; }

        public virtual Artist Artist { get; set; } //el artista que es el producto//
    }
}
