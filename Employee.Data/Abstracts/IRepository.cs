
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Data.Abstracts
{
    public interface IRepository<T> where T: class
    {
        Task<int>Add(T entity);
        Task<int>Update(T entity);
        Task<int>Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);


    }
}
