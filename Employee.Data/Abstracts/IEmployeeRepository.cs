using Employee.Domain.Entities;

namespace Employee.Data.Abstracts
{
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
    }
}
