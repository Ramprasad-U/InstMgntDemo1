using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstitueMgntDemoApiData;

namespace InstitueMgntDemoApi.Services
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentInfo>> GetStudentInfos();
        Task<StudentInfo> GetStudentInfoById(int id);
        Task<StudentInfo> GetStudentInfoByEmail(string email);
        Task<StudentInfo> AddStudentInfo(StudentInfo studentInfo);
    }
}
