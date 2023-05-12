using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.GenericRepo
{
    public interface IGenericRepo <T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
       void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        int SaveChanges();
        public List<Meal> GetAllWithIncludes(params Expression<Func<Meal, object>>[] includes);
    }
}
