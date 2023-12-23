using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UpdateMyList.Entity.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Read();
        T ReadByCreate(T t);
        T ReadById(object id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
        void DeleteRange(List<T> t);
        void Delete(int id);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly myListEntities _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(myListEntities context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }
        public virtual IQueryable<T> Read()
        {
            return DbSet;
        }
        public T ReadByCreate(T t)
        {
            if (t == null) throw new ArgumentNullException("t");
            DbSet.Add(t);
            _context.SaveChanges();
            return t;
        }
        public virtual T ReadById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public virtual void Create(T t)
        {
            if (t == null) throw new ArgumentNullException("t");
            DbSet.Add(t);
        }

        public virtual void Update(T t)
        {
            if (t == null) throw new ArgumentNullException("t");

            DbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }

        public virtual void Delete(T t)
        {
            if (t == null) throw new ArgumentNullException("t");
            if (_context.Entry(t).State == EntityState.Detached)
            {
                DbSet.Attach(t);
            }
            DbSet.Remove(t);
        }
        public virtual void DeleteRange(List<T> t)
        {
            if (t == null) throw new ArgumentNullException("t");
            //if (_context.Entry(t).State == EntityState.Detached)
            //{
            //    DbSet.Attach(t);
            //}
            DbSet.RemoveRange(t);
        }
        public virtual void Delete(int id)
        {
            var t = ReadById(id);
            Delete(t);
        }
    }
}
