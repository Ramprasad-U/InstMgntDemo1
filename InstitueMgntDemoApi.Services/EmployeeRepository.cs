using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstitueMgntDemoApiData;
using Microsoft.EntityFrameworkCore;

namespace InstitueMgntDemoApi.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            _appDbContext.Set<Employee>().Add(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;

            //throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmpEmail == email);

            //throw new NotImplementedException();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);

            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();

            //throw new NotImplementedException();
        }
    }
}
