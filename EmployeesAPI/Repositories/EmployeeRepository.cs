using EmployeesAPI.Data;
using EmployeesAPI.IRepositories;
using EmployeesAPI.Models;

namespace EmployeesAPI.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context) { }
    }
}
