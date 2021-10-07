using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstitueMgntDemoApiData;
using Microsoft.EntityFrameworkCore;


namespace InstitueMgntDemoApi.Services
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<StudentInfo> AddStudentInfo(StudentInfo studentInfo)
        {
            _appDbContext.Set<StudentInfo>().Add(studentInfo);
            await _appDbContext.SaveChangesAsync();
            return studentInfo;
            //throw new NotImplementedException();
        }

        public async Task<StudentInfo> GetStudentInfoByEmail(string email)
        {
            return await _appDbContext.StudentInfos.FirstOrDefaultAsync(x => x.Email == email);
            //throw new NotImplementedException();
        }

        public async Task<StudentInfo> GetStudentInfoById(int id)
        {
            return await _appDbContext.StudentInfos.FirstOrDefaultAsync(x => x.StudentInfoId == id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentInfo>> GetStudentInfos()
        {
            return await _appDbContext.StudentInfos.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
