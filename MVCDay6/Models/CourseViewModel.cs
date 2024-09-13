using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class CourseViewModel
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
        public int instructorsId { get; set; }
    }
}
