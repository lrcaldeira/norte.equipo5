using norte.equipo5.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Data.Services
{
    public interface IObraData
    {
        IEnumerable<Obra> GetAll();
    }
}
