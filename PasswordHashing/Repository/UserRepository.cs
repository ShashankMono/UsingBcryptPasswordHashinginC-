using Microsoft.EntityFrameworkCore;
using PasswordHashing.Data;

namespace PasswordHashing.Repository
{
    public class UserRepository<T>:IRepository<T> where T : class
    {
        private readonly UserContext _context;
        private readonly DbSet<T> _table;
        public UserRepository(UserContext context) {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges(); 
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }
    }
}
