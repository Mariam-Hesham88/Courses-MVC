using MVCDay6.Models.Entities;
using MVCDay6.Repo.Repositories;

namespace MVCDay6.Repo.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public IEnumerable<Department> Search(string name);
        //public IEnumerable<Department> GetAll();
        //public Department GetById(int id);
        //public int Add(Department dept);
        //public int Update(Department department);
        //public int Remove(Department department);

    }
}
