using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay6.Models.Entities
{
    public class Course : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[UniqueName]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter correct value")]
        public double Degree { get; set; }

        [Range(50, 100, ErrorMessage = "Please enter correct value")]
        public double MinDegree { get; set; }
        public ICollection<Instructor> instructors { get; set; }

        [ForeignKey("Instructor")]
        public int instructorsId { get; set; }
        public ICollection<CourseResult> courseResult { get; set; }

    }
}
