namespace EmployeesAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }
        public Guid DepartmentId { get; set; }
        public Department? Department { get; set; }
        
        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
}
