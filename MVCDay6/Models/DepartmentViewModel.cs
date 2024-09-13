using MVCDay6.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCDay6.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Depart name"), MinLength(2)]
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public int instructorsId { get; set; }
    }
}
