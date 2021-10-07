using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class SubjectServiceFake : ISubjectRepository
    {
        private readonly List<Subject> _subject;
        public SubjectServiceFake()
        {
            _subject = new List<Subject>()
            {
                new Subject()
                {
                    SubjectId = 1,
                    SubjectCode = "PHS01",
                    SubjectName ="Phy"
                },
                new Subject()
                {
                    SubjectId = 2,
                    SubjectCode = "MA02",
                    SubjectName ="MATHS"
                }
            };
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            _subject.Add(subject);
            return await Task.FromResult<Subject>(subject);
            //return await Task.FromResult<Subject>(subject);
            //throw new NotImplementedException();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await Task.FromResult<Subject>(_subject.FirstOrDefault(x => x.SubjectId == id));
            //throw new NotImplementedException();
        }

        public async Task<Subject> GetSubjectByName(string Name)
        {
            return await Task.FromResult<Subject>(_subject.FirstOrDefault(x => x.SubjectName == Name));

            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await Task.FromResult<IEnumerable<Subject>>(_subject);
            //throw new NotImplementedException();
        }
    }
}
