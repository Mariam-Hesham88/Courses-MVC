using MVCDay6.Models.Entities;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Repo.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
         private readonly AppDbContext _Context;

        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _Context = context;
        }

        public IEnumerable<Department> Search(string name)
        {
            var result = _Context.departments.Where(d => d.Name.Trim().ToLower().ToLower().Contains(name.Trim().ToLower()));
            return result;
        }
            //public int Add(Department dept)
            //{
            //    _Context.departments.Add(dept);
            //    return _Context.SaveChanges();
            //}

            //public IEnumerable<Department> GetAll()
            //    => _Context.departments.ToList();

            //public Department GetById(int? id)
            //=> _Context.departments.FirstOrDefault(x => x.Id == id);

            //public int Update(Department department)
            //{
            //    _Context.departments.Update(department);
            //    return _Context.SaveChanges();
            //}

            //public int Delete(Department department)
            //{
            //    _Context.departments.Remove(department);
            //    return _Context.SaveChanges();
            //}

    }
}
