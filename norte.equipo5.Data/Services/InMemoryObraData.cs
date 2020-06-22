using norte.equipo5.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Services
{
    public class InMemoryObraData : IObraData
    {
        private List<Obra> obras;
        public InMemoryObraData()
        {
            obras = new List<Obra>();
            obras.Add(new Obra() { Id_Obra = 1, Id_Artista = 7, Nombre = "Campo de amapolas" });
            obras.Add(new Obra() { Id_Obra = 2, Id_Artista = 4, Nombre = "La persistencia de la memoria" });
            obras.Add(new Obra() { Id_Obra = 3, Id_Artista = 2, Nombre = "La Scapigliata" });
            obras.Add(new Obra() { Id_Obra = 4, Id_Artista = 7, Nombre = "Jardín de Giverny" });
            obras.Add(new Obra() { Id_Obra = 5, Id_Artista = 4, Nombre = "Torero alucinógeno" });
            obras.Add(new Obra() { Id_Obra = 6, Id_Artista = 1, Nombre = "Las Señoritas de Avignon" });
            obras.Add(new Obra() { Id_Obra = 7, Id_Artista = 2, Nombre = "La Última Cena" });
            obras.Add(new Obra() { Id_Obra = 8, Id_Artista = 5, Nombre = "La Grenouillère" });
            obras.Add(new Obra() { Id_Obra = 9, Id_Artista = 5, Nombre = "Almuerzo de remeros" });
            obras.Add(new Obra() { Id_Obra = 9, Id_Artista = 3, Nombre = "Campo de trigo con cipreses" });
        }
        public IEnumerable<Obra> GetAll()
        {
            return obras;
        }
    }
}
