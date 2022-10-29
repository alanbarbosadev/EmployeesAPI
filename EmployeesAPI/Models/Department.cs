using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesAPI.Models
{
    public class Department
    {
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
