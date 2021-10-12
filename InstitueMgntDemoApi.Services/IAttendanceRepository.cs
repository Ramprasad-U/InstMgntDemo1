using InstitueMgntDemoApiData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAttendances();
        Task<Attendance> GetAttendancesById(int id);
        //Task<Attendance> GetsubBelongsId(int subBelongsId);
        //subBelongsId
        Task<Attendance> AddAttendance(Attendance attendance);

    }
}
