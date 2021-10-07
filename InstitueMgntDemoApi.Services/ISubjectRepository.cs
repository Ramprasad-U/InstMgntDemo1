using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> GetSubjectByName(string Name);
        Task<Subject> AddSubject(Subject subject);
    }
}
