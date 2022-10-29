using EmployeesAPI.Data;
using EmployeesAPI.IRepositories;
using EmployeesAPI.Models;

namespace EmployeesAPI.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DataContext context) : base(context) { }
    }
}
