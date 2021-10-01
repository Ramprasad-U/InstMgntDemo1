using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using InstitueMgntDemoApiData;
using Microsoft.EntityFrameworkCore;

namespace InstitueMgntDemoApi.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task <Department> GetDepartmentById(int id)
        {
            return await _appDbContext.Departments.FirstOrDefaultAsync (x => x.DepartmentId == id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            //throw new NotImplementedException();
            return await _appDbContext.Departments.ToListAsync();
        }
    }
}
