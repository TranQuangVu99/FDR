using FDR.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDR.Repositories.Implement
{
    public class BaseRepositories<T> : IBase<T> where T : class
    {

        private DbEntities db;

        DbSet<T> dbSet;
        public BaseRepositories()
        {
            db = new DbEntities();
            dbSet = db.Set<T>();
        }

        public bool Delete(object id)
        {
            try
            {
                T obj = db.Set<T>().Find(id);
                db.Set<T>().Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            
             return db.Set<T>().ToList();
           
        }

        public T GetById(object id)
        {
            return db.Set<T>().Find(id);
        }

        public T Insert(T obj)
        {
            try
            {
                db.Set<T>().Add(obj);
                db.SaveChanges();
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public bool Update(T obj)
        {
            db = new DbEntities();
            try
            {
                db.Entry<T>(obj).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return db.Set<T>().Where(where).ToList();
        }
    }
}
