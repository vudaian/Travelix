using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using travelix.Model.Entities;

namespace travelix.Repository
{
    public class GennericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TravelixContext _context;
        private readonly DbSet<T> _entities;
        public GennericRepository(TravelixContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T entity = GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
