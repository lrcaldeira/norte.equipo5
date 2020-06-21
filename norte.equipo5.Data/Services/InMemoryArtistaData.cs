using norte.equipo5.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static norte.equipo5.Data.Model.Artista;

namespace norte.equipo5.Data.Services
{
    public class InMemoryArtistaData : IArtistaData
    {
        private List<Artista> artistas;

        public InMemoryArtistaData()
        {
            artistas = new List<Artista>();
            artistas.Add(new Artista() { Id = 1, Apellido = "Picasso", Nombre = "Pablo", Estilo = TipoEstilo.Expresionismo });
            artistas.Add(new Artista() { Id = 2, Apellido = "Da Vinci", Nombre = "Leonardo", Estilo = TipoEstilo.Renacimiento });
            artistas.Add(new Artista() { Id = 3, Apellido = "Van Gogh", Nombre = "Vincent", Estilo = TipoEstilo.Postimpresionismo });
            artistas.Add(new Artista() { Id = 4, Apellido = "Dalí", Nombre = "Salvador", Estilo = TipoEstilo.Surrealismo });
            artistas.Add(new Artista() { Id = 5, Apellido = "Renoir", Nombre = "Pierre Auguste", Estilo = TipoEstilo.Impresionismo });
            artistas.Add(new Artista() { Id = 6, Apellido = "de Goya", Nombre = "Francisco", Estilo = TipoEstilo.Realismo });
            artistas.Add(new Artista() { Id = 7, Apellido = "Monet", Nombre = "Claude", Estilo = TipoEstilo.Impresionismo });
        }

        public IEnumerable<Artista> GetAll()
        {
            return artistas.OrderBy(o => o.Apellido);
        }
    }
}
