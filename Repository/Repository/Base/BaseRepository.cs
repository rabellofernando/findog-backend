using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<T>  where T : class
    {
        private ServerContext Context;

        public BaseRepository(ServerContext _context)
        {
            Context = _context;
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public IQueryable<T> Get(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = Context.Set<T>();
            if (includes.Any())
                includes.ToList().ForEach(f => result = result.Include(f));
            return result;
        }

        public T Get(int id, params Expression<Func<T, object>>[] includes)
        {
            var item = Expression.Parameter(typeof(T), "item");
            var byId = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Property(item, "Id" ), Expression.Constant(id)), item);

            return Get(includes).FirstOrDefault(byId);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            T query = Context.Set<T>().FirstOrDefault(predicate);
            return query;
        }

        public IQueryable<T> FindListBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var query = Context.Set<T>().Where(predicate);
            return query;
        }
    }
}
