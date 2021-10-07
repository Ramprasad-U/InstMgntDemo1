using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);

    }
}
