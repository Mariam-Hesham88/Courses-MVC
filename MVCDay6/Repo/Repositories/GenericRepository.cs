using MVCDay6.Models.Entities;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Repo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _Context;

        public GenericRepository(AppDbContext context)
        {
            _Context = context;
        }

        public int Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            return _Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           return _Context.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            return _Context.Set<T>().Find(id);
        }

        public int Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
            return _Context.SaveChanges();
        }

        public int Update(T entity)
        {
            _Context.Set<T>().Update(entity);
            return _Context.SaveChanges();
        }
    }
}
