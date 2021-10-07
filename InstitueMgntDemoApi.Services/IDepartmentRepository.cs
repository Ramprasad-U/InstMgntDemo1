using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstitueMgntDemoApiData;

namespace InstitueMgntDemoApi.Services
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department department);
        Task<Department> GetDepartmentByName(string Name);
    }
}
