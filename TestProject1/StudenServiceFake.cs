using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstitueMgntDemoApi;
using InstitueMgntDemoApiData;
using InstitueMgntDemoApi.Services;

namespace TestProject1
{
    public class StudenServiceFake : IStudentRepository
    {
        private readonly List<StudentInfo> _studentInfo;
        public StudenServiceFake()
        {
            _studentInfo = new List<StudentInfo>()
            {
                new StudentInfo()
                {
                    StudentInfoId = 1,
                    Name = "Legosy",
                    Email = "Legosy@gmail.com",
                    Gender = Gender.Male,
                    DateOfBrith = new DateTime(1986,05,26)
        },
                new StudentInfo()
                {

                    StudentInfoId = 2,
                    Name = "Dylato",
                    Email = "Dylato@gmail.com",
                    Gender = Gender.Male,
                    DateOfBrith = new DateTime(1990,02,21)

                },
                new StudentInfo()
                {

                    StudentInfoId = 3,
                    Name = "Ulana",
                    Email = "Ulana@gmail.com",
                    Gender = Gender.Female,
                    DateOfBrith = new DateTime(1990,06,01)

                }
            };

        }
        public async Task<StudentInfo> AddStudentInfo(StudentInfo studentInfo)
        {
            _studentInfo.Add(studentInfo);
            return await Task.FromResult<StudentInfo>(studentInfo);

            //throw new NotImplementedException();
        }

        public async Task<StudentInfo> GetStudentInfoByEmail(string email)
        {
            return await Task.FromResult<StudentInfo>(_studentInfo.FirstOrDefault(x => x.Email == email));
            //throw new NotImplementedException();
        }

        public async Task<StudentInfo> GetStudentInfoById(int id)
        {
            return await Task.FromResult<StudentInfo>(_studentInfo.FirstOrDefault(x => x.StudentInfoId == id));

            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentInfo>> GetStudentInfos()
        {
            return await Task.FromResult<IEnumerable<StudentInfo>>(_studentInfo);

            //throw new NotImplementedException();
        }
    }
}
