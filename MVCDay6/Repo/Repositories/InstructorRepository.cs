using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Repo.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>,IInstructorRepository
    {
        //private readonly AppDbContext _Context;

        public InstructorRepository(AppDbContext context) : base(context)
        {
            //_Context = context;
        }

        //public int Add(Instructor instructor)
        //{
        //    _Context.instructors.Add(instructor);
        //    return _Context.SaveChanges();
        //}

        //public IEnumerable<Instructor> GetAll()
        //=> _Context.instructors.ToList();

        //public Instructor GetById(int? id)
        //=> _Context.instructors.FirstOrDefault(i => i.Id == id);

        //public int Update(Instructor instructor)
        //{
        //    _Context.instructors.Update(instructor);
        //    return _Context.SaveChanges();
        //}

        //public int Delete(Instructor instructor)
        //{
        //    _Context.instructors.Remove(instructor);
        //    return _Context.SaveChanges();
        //}
    }
}
