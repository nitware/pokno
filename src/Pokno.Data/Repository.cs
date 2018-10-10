using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using System.Data.Entity;
using System.Threading.Tasks;
using Pokno.Entity;
using Pokno.Business.Interfaces;

namespace Pokno.Data
{
    public class Repository : IRepository
    {
        public PoknoEntities _context;

        public Repository(string dbFilePath) : this(new PoknoEntities(string.Format(@"metadata=res://*/PoknoModel.csdl|res://*/PoknoModel.ssdl|res://*/PoknoModel.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=""{0}""{1}'", dbFilePath, ";foreign keys=True;pooling=True;Max Pool Size=100"))) { }

        public Repository(PoknoEntities context)
        {
            _context = context;
        }

        public PoknoEntities DbContext 
        {
            get { return _context; }
            set
            {
                _context = value;
            }
        }

        //public dynamic GetMaxValueBy<E>(Func<E, dynamic> match) where E : class
        //{
        //    try
        //    {
        //        dynamic maximum = 0;
        //        DbSet<E> es = _context.Set<E>();
        //        if (es != null && es.Count() > 0)
        //        {
        //            maximum = _context.Set<E>().Max(match);
        //        }

        //        return maximum;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
                       
        public int GetMaxValueBy<E>(Func<E, int> match) where E : class
        {
            try
            {
                int maximum = 0;
                DbSet<E> es = _context.Set<E>();
                if (es != null && es.Count() > 0)
                {
                    maximum = _context.Set<E>().Max(match);
                }

                return maximum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long GetMaxValueBy<E>(Func<E, long> match) where E : class
        {
            try
            {
                long maximum = 0;
                DbSet<E> es = _context.Set<E>();
                if (es != null && es.Count() > 0)
                {
                    maximum = _context.Set<E>().Max(match);
                }

                return maximum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<E> GetTopBy<E>(int top, Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "") where E : class
        {
            try
            {
                //List<E> list = null;
                //List<E> entities = _context.Set<E>().Where(match).ToList();
                //if (entities != null && entities.Count() > 0)
                //{
                //    list = entities.Take(top).ToList();
                //}

                //return list;

                List<E> list = null;
                List<E> entities = GetBy<E>(filter, orderBy, includeProperties);
                if (entities != null && entities.Count() > 0)
                {
                    list = entities.Take(top).ToList();
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<E> GetAll<E>() where E : class
        {
            try
            {
                return _context.Set<E>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public E GetBy<E>(object id) where E : class
        {
            try
            {
                return _context.Set<E>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public E GetSingleBy<E>(Expression<Func<E, bool>> match) where E : class
        {
            try
            {
                return _context.Set<E>().SingleOrDefault(match);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<E> FindAll<E>(Expression<Func<E, bool>> match) where E : class
        {
            try
            {
                return _context.Set<E>().Where(match).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<E> GetBy<E>(Expression<Func<E, bool>> filter = null, Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeProperties = "") where E : class
        {
            try
            {
                IQueryable<E> query = _context.Set<E>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public E Add<E>(E e) where E : class
        {
            try
            {
                E newE = _context.Set<E>().Add(e);
                return newE;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Add<E>(ICollection<E> es) where E : class
        {
            try
            {
                foreach (E e in es)
                {
                    _context.Set<E>().Add(e);
                }

                //context.Set<E>().AddRange(es);

                return es.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<E> AddCollection<E>(ICollection<E> es) where E : class
        {
            try
            {
                return _context.Set<E>().AddRange(es);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Delete<E>(E e) where E : class
        {
            try
            {
                //context.Entry(itemTypeItem).State = EntityState.Deleted;

                DbSet<E> dbSet = _context.Set<E>();
                if (_context.Entry(e).State == EntityState.Detached)
                {
                    dbSet.Attach(e);
                }

                dbSet.Remove(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<E>(Expression<Func<E, bool>> predicate) where E : class
        {
            try
            {
                DbSet<E> dbSet = _context.Set<E>();
                IEnumerable<E> records = from x in dbSet.Where<E>(predicate) select x;

                foreach (E e in records)
                {
                    if (_context.Entry(e).State == EntityState.Detached)
                    {
                        dbSet.Attach(e);
                    }

                    dbSet.Remove(e);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<E>(List<E> es) where E : class
        {
            try
            {
                DbSet<E> dbSet = _context.Set<E>();
                foreach (E e in es)
                {
                    if (_context.Entry(e).State == EntityState.Detached)
                    {
                        dbSet.Attach(e);
                    }

                    dbSet.Remove(e);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<E>(object id) where E : class
        {
            try
            {
                DbSet<E> dbSet = _context.Set<E>();
                E e = dbSet.Find(id);

                if (_context.Entry(e).State == EntityState.Detached)
                {
                    dbSet.Attach(e);
                }

                dbSet.Remove(e);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update<E>(E e) where E : class
        {
            try
            {
                DbSet<E> dbSet = _context.Set<E>();
                dbSet.Attach(e);
                _context.Entry(e).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update<E>(List<E> es) where E : class
        {
            try
            {
                DbSet<E> dbSet = _context.Set<E>();
                foreach (E e in es)
                {
                    dbSet.Attach(e);
                    _context.Entry(e).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Count<E>() where E : class
        {
            try
            {
                return _context.Set<E>().Count();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


      





    }




}

 //<!--<connectionStrings>
 //   <add name="PoknoV41Entities" connectionString="metadata=res://*/PoknoV41Model.csdl|res://*/PoknoV41Model.ssdl|res://*/PoknoV41Model.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=&quot;C:\Users\Dan\Documents\Visual Studio 2013\Projects\PoknoV41\PoknoV41.Shell\db\PoknoV41.db&quot;'" providerName="System.Data.EntityClient" />
 // </connectionStrings>-->
 //<!--<connectionStrings>
 //   <add name="PoknoV41Entities" connectionString="metadata=res://*/PoknoV41Model.csdl|res://*/PoknoV41Model.ssdl|res://*/PoknoV41Model.msl;provider=System.Data.SQLite.EF6;provider connection string='data source=&quot;C:\Users\Dan\Documents\Visual Studio 2013\Projects\PoknoV41\PoknoV41.Shell\db\PoknoV41.db&quot;'" providerName="System.Data.EntityClient" />
 // </connectionStrings>-->