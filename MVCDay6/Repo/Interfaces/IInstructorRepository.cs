using MVCDay6.Models.Entities;

namespace MVCDay6.Repo.Interfaces
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        public IEnumerable<Instructor> Search(string name);
        //public IEnumerable<Instructor> GetAll();
        //public Instructor GetById(int id);
        //public int Add(Instructor instructor);
        //public int Update(Instructor instructor);
        //public int Delete(Instructor instructor);
    }
}
