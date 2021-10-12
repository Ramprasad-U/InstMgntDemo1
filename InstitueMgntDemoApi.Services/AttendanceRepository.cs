using InstitueMgntDemoApiData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public class AttendanceRepository: IAttendanceRepository
    {
        private readonly AppDbContext _appDbContext;

        public AttendanceRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<Attendance> AddAttendance(Attendance attendance)
        {
            if (attendance.AttendanceDetails != null)
            {
                _appDbContext.Entry(attendance.AttendanceDetails).State = EntityState.Unchanged;
            }
            if (attendance.studentEnroll != null)
            {
                _appDbContext.Entry(attendance.studentEnroll).State = EntityState.Unchanged;
            }

            var result = await _appDbContext.Attendances.AddAsync(attendance);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;

            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            return await _appDbContext.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendancesById(int id)
        {
            return await _appDbContext.Attendances.FirstOrDefaultAsync(x => x.id == id);
            //throw new NotImplementedException();
        }
    }
}
