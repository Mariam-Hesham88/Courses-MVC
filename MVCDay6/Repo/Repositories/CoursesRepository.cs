using MVCDay6.Models;
using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Repo.Repositories
{
    public class CoursesRepository : GenericRepository<Course>,ICoursesRepository
    {
        //private readonly AppDbContext _context;

        public CoursesRepository(AppDbContext context) : base(context)
        {
            //_context = context;
        }

        //public int Add(Course course)
        //{
        //    _context.courses.Add(course);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Course> GetAll()
        //=> _context.courses.ToList();

        //public Course GetById(int? id)
        //=> _context.courses.FirstOrDefault(c => c.Id == id);

        //public int Update(Course course)
        //{
        //    _context.courses.Update(course);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Course course)
        //{
        //    _context.courses.Remove(course);
        //    return _context.SaveChanges();
        //}

    }
}
