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
    public class AttendanceDetailsServiceFake: IAttendanceDetailsRepository
    {
        private readonly List<AttendanceDetails> _attdDetails;

        public AttendanceDetailsServiceFake()
        {
            _attdDetails = new List<AttendanceDetails>()
            {
                new AttendanceDetails()
                {
                    id = 1,
                    date = new DateTime(2021,11,01),
                    subBelongsId = 5
                },
                new AttendanceDetails()
                {
                    id = 2,
                    date = new DateTime(2021,11,04),
                    subBelongsId = 5
                },
                new AttendanceDetails()
                {
                    id = 3,
                    date = new DateTime(2021,11,01),
                    subBelongsId = 1
                }
            };

        }
        public async Task<IEnumerable<AttendanceDetails>> GetAttendanceDetails()
        {
            return await Task.FromResult<IEnumerable<AttendanceDetails>>(_attdDetails);
            //throw new NotImplementedException();
        }

        public async Task<AttendanceDetails> GetAttendanceDetailsById(int id)
        {
            return await Task.FromResult<AttendanceDetails>(_attdDetails.FirstOrDefault(x => x.id == id));

            //throw new NotImplementedException();
        }

        public async Task<AttendanceDetails> GetsubBelongsId(int subBelongsId)
        {
            return await Task.FromResult<AttendanceDetails>(_attdDetails.FirstOrDefault(x => x.subBelongsId == subBelongsId));

            //throw new NotImplementedException();
        }

        public async Task<AttendanceDetails> AddAttdDetails(AttendanceDetails attendanceDetails)
        {
            _attdDetails.Add(attendanceDetails);
            return await Task.FromResult<AttendanceDetails>(attendanceDetails);
            //throw new NotImplementedException();
        }


    }
}
