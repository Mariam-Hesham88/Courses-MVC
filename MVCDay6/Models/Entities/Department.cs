using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDay6.Models.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Depart name"), MinLength(2)]
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Instructor> instructors { get; set; }

        [ForeignKey("Instructor")]
        public int instructorsId { get; set; }
    }
}
