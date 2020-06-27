using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace norte.equipo5.Services
{
    //CRUD implementa el patron CRUD//
    public interface IDataService<T>
    {
        List<ValidationResult> ValidateModel(T Model); // cuando mando a guardar algo , hace el validatemodel y esto esta vacia es que esta todo ok con el modelo// 

        List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeModels = "");
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

    }
}
