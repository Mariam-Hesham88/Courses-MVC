using MVCDay6.Models;

namespace MVCDay6.Repo.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();
        public T GetById(int? id);
        public int Add(T entity);
        public int Update(T entity);
        public int Delete(T entity);
    }
}
