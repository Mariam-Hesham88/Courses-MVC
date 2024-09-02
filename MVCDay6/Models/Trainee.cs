using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Trainee name"), MinLength(2)]
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public string Address { get; set; }
        [Range(0, 100, ErrorMessage = "Please enter correct value")]
        public double Grade { get; set; }
        public ICollection<CourseResult> courseResult { get; set; }
        public int courseResultId { get; set; }
    }
}
