﻿using Microsoft.AspNetCore.Mvc;
using MVCDay6.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class InstructorViewModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name"), MinLength(3)]
        public string Name { get; set; }

        public IFormFile Image { get; set; }
        public string? ImgSrc { get; set; }

        // -------> [Range(8000, 50000, ErrorMessage = "Please enter correct value")]
        [Remote("CheckSalary", "Employee", AdditionalFields = "DeptId", ErrorMessage = "value of salary not match")]
        public double Salary { get; set; }

        [RegularExpression("(Cairo|Giza)", ErrorMessage = "Please enter Cairo or Giza")]
        public string Address { get; set; }
    }
}
