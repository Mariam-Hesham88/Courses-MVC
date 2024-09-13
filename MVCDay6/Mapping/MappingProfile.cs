using AutoMapper;
using MVCDay6.Models;
using MVCDay6.Models.Entities;

namespace MVCDay6.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instructor, InstructorViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();
        }
    }
}
