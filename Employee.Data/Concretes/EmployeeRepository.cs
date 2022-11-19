using Employee.Data.Abstracts;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Employee.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace Employee.Data.Concretes
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(EmployeeEntity entity)
        {
            var sql = "INSERT INTO Employees (Name,Surname,Gender,Email,Salary,IsDeleted) VALUES (@Name,@Surname,@Gender,@Email,@Salary,'false') ";
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Employees WHERE Id = @Id";
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<List<EmployeeEntity>> GetAll()
        {
            var sql = "SELECT * FROM Employees";
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.QueryAsync<EmployeeEntity>(sql);
                return result.ToList();
            }
        }

        public async Task<EmployeeEntity> GetById(int id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.QuerySingleOrDefaultAsync<EmployeeEntity>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> Update(EmployeeEntity entity)
        {
            var sql = "INSERT INTO Employees (Name,Surname,Gender,Email,Salary,IsDeleted) VALUES (@Name,@Surname,@Gender,@Email,@Salary,'false')";
            using (var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                con.Open();
                var result = await con.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
