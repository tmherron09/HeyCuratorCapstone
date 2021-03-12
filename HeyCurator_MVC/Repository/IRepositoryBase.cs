using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Save();
        Task SaveAsync();
        void Delete(T entity);


    }
}
