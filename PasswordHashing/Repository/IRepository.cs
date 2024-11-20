namespace PasswordHashing.Repository
{
    public interface IRepository<T>
    {
        public T Add(T entity);
        public IQueryable<T> GetAll();
    }
}
