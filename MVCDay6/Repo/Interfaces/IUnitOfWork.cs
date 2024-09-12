namespace MVCDay6.Repo.Interfaces
{
    public interface IUnitOfWork
    {
        public IInstructorRepository InstructorRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }
        public ICoursesRepository CoursesRepository { get; set; }
    }
}
