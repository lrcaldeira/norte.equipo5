using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using norte.equipo5.Data.Model;

namespace norte.equipo5.Data.Services
{
    public class GaleriaDBContext : DbContext
    {
        public GaleriaDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<GaleriaDBContext>(null);


        }
        ///<sumary>
        ///PluralizingTableNameConvention
        /// </sumary>
        /// <param name ="modelBuilder" ></param>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Artist> Artist { get; set; }

        public virtual DbSet<Product> Product { get; set; }

        public virtual DbSet<Error> Error { get; set; }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<OrderNumber> OrderNumber { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }

    }
}

  