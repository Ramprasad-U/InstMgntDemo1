using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
using InstitueMgntDemoApi;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class DepartmentServiceFake: IDepartmentRepository
    {
        private readonly List<Department> _department;
        public DepartmentServiceFake()
        {
            _department = new List <Department>()
            {
                new Department(){
                    DepartmentId = 1,DepartmentName="faculty"
                },
                new Department() {
                    DepartmentId = 2,DepartmentName="admin"
                }
            };

        }

        public async Task<Department> GetDepartmentById(int id)
        {
            //throw new NotImplementedException();
            return await Task.FromResult<Department>(_department.FirstOrDefault(x => x.DepartmentId == id));
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            //return _department.ToList();
            return await Task.FromResult<IEnumerable<Department>>(_department);
            //throw new NotImplementedException();
            
        }
    }
}
