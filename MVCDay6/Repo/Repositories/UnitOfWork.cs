using MVCDay6.Repo.Interfaces;

namespace MVCDay6.Repo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IInstructorRepository InstructorRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public ICoursesRepository CoursesRepository { get; set; }
        public UnitOfWork(
            IDepartmentRepository departmentRepository,
            IInstructorRepository instructorRepository,
            ICoursesRepository coursesRepository
            ) 
        { 
            DepartmentRepository = departmentRepository;
            InstructorRepository = instructorRepository;
            CoursesRepository = coursesRepository;
        }
    }
}
