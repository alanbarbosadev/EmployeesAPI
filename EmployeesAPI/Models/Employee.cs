using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesAPI.Models
{
    public class Employee
    {
        public Employee(int id, string name, string surname, double salary, DateTime birthday, int departmentId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Salary = salary;
            Birthday = birthday;
            DepartmentId = departmentId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
