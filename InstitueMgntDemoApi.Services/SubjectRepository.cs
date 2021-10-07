using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstitueMgntDemoApi.Services
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubjectRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            //throw new NotImplementedException();
            return await _appDbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _appDbContext.Subjects.FirstOrDefaultAsync(x => x.SubjectId == id);
            //throw new NotImplementedException();
        }

        public async Task<Subject> GetSubjectByName(string Name)
        {
            return await _appDbContext.Subjects.FirstOrDefaultAsync(x => x.SubjectName == Name);
            //throw new NotImplementedException();
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            _appDbContext.Set<Subject>().Add(subject);
            await _appDbContext.SaveChangesAsync();
            return subject;
            //throw new NotImplementedException();
        }
    }
}
