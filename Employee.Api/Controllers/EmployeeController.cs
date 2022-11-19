using Employee.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employee.Domain.Entities;
using System.Threading.Tasks;
using Employee.Service.Dtos;

namespace Employee.Api.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeedto)
        {
            await employeeService.Add(employeedto);
            return Ok();
        }
        [HttpGet("List")] //TODO

        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await employeeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public  async Task<IActionResult> GetEmployeeById(int id)
        {
            var result =await employeeService.GetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeedto,int id)
        {
            await employeeService.Update(employeedto,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeService.Delete(id);
            return Ok();
        }
    }
}
