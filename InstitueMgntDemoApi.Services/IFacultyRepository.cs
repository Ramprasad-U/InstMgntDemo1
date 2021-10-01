using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstitueMgntDemoApiData;
namespace InstitueMgntDemoApi.Services
{
    public interface IFacultyRepository
    {
        //Task<IEnumerable<FacultyAssignToSubject>> GetAll();
        //camel case
        //get the assgined subject to a faculty by id
        Task<FacultyAssignToSubject> GetFacultyAssignToSubjectById(int Id);
        //assigning the faculty to the subject
        Task<FacultyAssignToSubject> assignFacultyToSubject(FacultyAssignToSubject facultyAssignToSubject);
        
        //get the subjects  belongs to the faculty and later version we will show by empid
        Task<IEnumerable<object>> mySubjectsList();
        //Task<IQueryable> GetmySubjectList();

        // list the students who are enroll (under for the branch, sem and section) under the selected subject => branch,
        Task<IEnumerable<object>> listStubysubbelongstoid(int subid);
       
    }
}
