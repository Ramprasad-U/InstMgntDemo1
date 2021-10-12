using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public interface IAttendanceDetailsRepository
    {
        Task<IEnumerable<AttendanceDetails>> GetAttendanceDetails();
        Task<AttendanceDetails> GetAttendanceDetailsById(int id);
        Task<AttendanceDetails> GetsubBelongsId(int subBelongsId);
        //subBelongsId
        Task<AttendanceDetails> AddAttdDetails(AttendanceDetails attendanceDetails);
    }
}
