using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class CourseResult : BaseEntity
    {
            [Key]
            public int Id { get; set; }
 
            [Range(0, 100, ErrorMessage = "Please enter correct value")]
            public double Degree { get; set; }
    }
}
