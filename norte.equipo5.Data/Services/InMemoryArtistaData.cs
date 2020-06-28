using norte.equipo5.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static norte.equipo5.Data.Model.Artist;


namespace norte.equipo5.Data.Services
{
    public class InMemoryArtistaData : BaseDataService<Artist>
    {
        private List<Artist> artistas;

        public InMemoryArtistaData()
        {
            artistas = new List<Artist>();
            new Artist() { Id = 1, LastName = "Picasso", FirstName = "Pablo"};
            new Artist() { Id = 2, LastName = "Da Vinci", FirstName = "Leonardo" };
            new Artist() { Id = 3, LastName = "Van Gogh", FirstName = "Vincent"};
            new Artist() { Id = 4, LastName = "Dalí", FirstName = "Salvador"};
            new Artist() { Id = 5, LastName = "Renoir", FirstName = "Pierre Auguste" };
            new Artist() { Id = 6, LastName = "de Goya", FirstName = "Francisco" };
            new Artist() { Id = 7, LastName = "Monet", FirstName = "Claude" };
        }

        public override List<Artist> Get(Expression<Func<Artist, bool>> whereExpression = null, Func<IQueryable<Artist>, IOrderedQueryable<Artist>> orderFunction = null, string includeEntities="")     
            {
            return artistas.OrderBy(o => o.LastName).ToList();
        
        }
        //public IEnumerable<Artista> GetAll()
        //{
        //    this.
        //    return artistas.OrderBy(o => o.Apellido);
        //}
    }
}
