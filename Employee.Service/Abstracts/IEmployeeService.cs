using Employee.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Employee.Service.Abstracts
{
    public interface IEmployeeService
    {
        Task Add(EmployeeDto employeeDto);
        Task Delete(int id);
        Task Update(EmployeeDto employeeDto,int id);
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
    }
}
