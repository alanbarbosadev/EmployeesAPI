using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesAPI.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(2, ErrorMessage = "This Field Must Contain 2 Or More Characters!")]
        [MaxLength(20, ErrorMessage = "This Field Must Contain 20 Or Less Characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MinLength(2, ErrorMessage = "This Field Must Contain 2 Or More Characters!")]
        [MaxLength(30, ErrorMessage = "This Field Must Contain 30 Or Less Characters!")]
        public string Surname { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
