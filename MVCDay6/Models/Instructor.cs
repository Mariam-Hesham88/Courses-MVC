using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name"), MinLength(3)]
        public string Name { get; set; }

        //[RegularExpression(@"[a-z]+\.(jpg)", ErrorMessage = ("you must upload image with jpg "))]
        public string? ImgSrc { get; set; }

        // -------> [Range(8000, 50000, ErrorMessage = "Please enter correct value")]
        [Remote("CheckSalary", "Employee", AdditionalFields = "DeptId", ErrorMessage = "value of salary not match")]
        public double Salary { get; set; }

        [RegularExpression("(Cairo|Giza)", ErrorMessage = "Please enter Cairo or Giza")]
        public string Address { get; set; }


    }
}
