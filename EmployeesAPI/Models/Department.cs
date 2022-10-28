using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesAPI.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(2, ErrorMessage = "This Field Must Contain 2 Or More Characters!")]
        [MaxLength(20, ErrorMessage = "This Field Must Contain 20 Or Less Characters!")]
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
