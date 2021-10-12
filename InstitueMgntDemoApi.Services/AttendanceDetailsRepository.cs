using InstitueMgntDemoApiData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApi.Services
{
    public class AttendanceDetailsRepository : IAttendanceDetailsRepository
    {
        private readonly AppDbContext _appDbContext;

        public AttendanceDetailsRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<AttendanceDetails> AddAttdDetails(AttendanceDetails attendanceDetails)
        {
            if (attendanceDetails.subjectBelongsTo != null)
            {
                _appDbContext.Entry(attendanceDetails.subjectBelongsTo).State = EntityState.Unchanged;
            }

            var result = await _appDbContext.AttendanceDetails.AddAsync(attendanceDetails);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;

            //_appDbContext.Set<AttendanceDetails>().Add(attendanceDetails);
            //await _appDbContext.SaveChangesAsync();
            //return attendanceDetails;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<AttendanceDetails>> GetAttendanceDetails()
        {
            return await _appDbContext.AttendanceDetails.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<AttendanceDetails> GetAttendanceDetailsById(int id)
        {
            return await _appDbContext.AttendanceDetails.FirstOrDefaultAsync(x => x.id == id);
            //throw new NotImplementedException();
        }

        public async Task<AttendanceDetails> GetsubBelongsId(int subBelongsId)
        {
            return await _appDbContext.AttendanceDetails.FirstOrDefaultAsync(x => x.subBelongsId == subBelongsId);
            //throw new NotImplementedException();
        }
    }
}
