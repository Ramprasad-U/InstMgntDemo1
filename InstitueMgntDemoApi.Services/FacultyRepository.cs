using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InstitueMgntDemoApi.Services
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDbContext _appDbContext;

        public FacultyRepository (AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<FacultyAssignToSubject> assignFacultyToSubject(FacultyAssignToSubject facultyAssignToSubject)
        {
            if(facultyAssignToSubject.Employee != null)
            {
                _appDbContext.Entry(facultyAssignToSubject.Employee).State = EntityState.Unchanged;
            }
            var result = await _appDbContext.FacultyAssignToSubjects.AddAsync(facultyAssignToSubject);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FacultyAssignToSubject> GetFacultyAssignToSubjectById(int Id)
        {
            return await _appDbContext.FacultyAssignToSubjects
                .Include(e => e.SubjectBelongsTo)
                //.ThenInclude(s=>s.Subject)
                .FirstOrDefaultAsync(e => e.Id == Id);

        }

        public async Task<IEnumerable<object>> listStubysubbelongstoid(int subid)
        {
            var stulist = from se in _appDbContext.StudentEnrolls
                          join sbt in _appDbContext.SubjectBelongsTos
                          on new { x1=se.BranchId, x2=se.Semester } equals new { x1=sbt.BranchId, x2=sbt.Sem }
                          join fsb in _appDbContext.FacultyAssignToSubjects
                          on new { x1 = sbt.id, x2 = se.Section } equals new { x1 = fsb.SubjectBelongsToId, x2 = fsb.Section }
                          where fsb.SubjectBelongsToId == subid
                          select new
                          {
                              studentenrollid = se.StudentEnrollId,
                              section = ((Section)se.Section).ToString(),
                              Semester = ((Semester)se.Semester).ToString()
                          };
            return await stulist.ToListAsync();

            //            select* from StudentEnrolls se
            //join SubjectBelongsTos sbt on se.BranchId = sbt.BranchId and se.Semester = sbt.Sem
            //--where sbt.id = 5
            //--and where se.Section = (select section from FacultyAssignToSubjects where SubjectBelongsToId = 5)
            //join FacultyAssignToSubjects fs on sbt.id = fs.SubjectBelongsToId and se.Section = fs.Section
            //--where fs.Section = 1
            //and sbt.id = 5



        }

        public async Task<IEnumerable<object>> mySubjectsList()
        {
            //var mysub = _appDbContext.FacultyAssignToSubjects
            //    .Include(sb => sb.SubjectBelongsTo)
            //    .ThenInclude(s => s.Subject)
            //    .Select(se => new
            //    {
            //        se.Subject.SubjectName,
            //        se.SubjectBelongsTo.Sem

            //    });
            //List<mysubject> mysubjects();
            var mysubjects = from s in _appDbContext.Subjects
                             join sub in _appDbContext.SubjectBelongsTos
                             on s.SubjectId equals sub.SubjectId
                             join fsb in _appDbContext.FacultyAssignToSubjects
                             on sub.id equals fsb.SubjectBelongsToId
                             join b in _appDbContext.Branches
                             on sub.BranchId equals b.BranchId
                             select new
                             {
                                 subjectcode = s.SubjectCode,
                                 subject = s.SubjectName,
                                 Branch = b.BranchName,
                                 Sem = ((Semester)sub.Sem).ToString(),
                                 Sec = ((Section)fsb.Section).ToString()

                             };
            return await mysubjects.ToListAsync();
            //select subjectcode,subjectName,sb.Sem, b.BranchCode,fs.Section from Subjects s
            //join SubjectBelongsTos sb on s.SubjectId = sb.SubjectId join facultyAssigntoSubjects fs
            //on sb.id = fs.SubjectBelongsToId join Branches b on sb.BranchId = b.BranchId

            //return _appDbContext.FacultyAssignToSubjects.Where(fs=>fs.SubjectBelongsToId == SubjectBelongsTo.Id)
            //    .Include(e=>e.SubjectBelongsToId)

            //             context.Blogs
            //.Include(blog => blog.Posts).ThenInclude(post => post.Tags).ThenInclude(tag => tag.TagInfo)
            //.Include(blog => blog.Contributors)
            //         //throw new NotImplementedException();
        }

    }
}
