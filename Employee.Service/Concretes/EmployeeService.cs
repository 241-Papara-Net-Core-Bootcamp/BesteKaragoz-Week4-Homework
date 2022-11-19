using Employee.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Data.Abstracts;
using AutoMapper;
using Employee.Service.Dtos;
using Employee.Domain.Entities;


namespace Employee.Service.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<EmployeeEntity>(employeeDto);
           await _repo.Add(employee);
        }
        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _repo.GetById(id);
            var employeeDtos =_mapper.Map<EmployeeDto>(employee);
            return employeeDtos;

        }
        public async Task<List<EmployeeDto>> GetAll()
        {
            var employee = await _repo.GetAll();
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employee);
            return employeeDtos;
        }
        public async Task Update(EmployeeDto employeeDto,int id)
        {
            var employee = await _repo.GetById(id);
            var updateEmployee = _mapper.Map<EmployeeEntity>(employeeDto);
            updateEmployee.Id = id;
            await _repo.Update(updateEmployee);
        }
        public async Task Delete(int id)
        {
            var employee = await _repo.GetById(id);
            await _repo.Delete(id);

        }

    }
    
    

}


