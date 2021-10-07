using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InstitueMgntDemoApiData
{
    public class Attendance
    {
        [Key]
        public int id { get; set; }
        public int attId { get; set; }
        [ForeignKey("attId")]
        public AttendanceDetails AttendanceDetails { get; set; }
        public int enrollId { get; set; }
        [ForeignKey("enrollId")]
        public StudentEnroll studentEnroll { get; set; }
        //public virtual List<StudentEnroll> studentEnroll { get; set; }
        //[ForeignKey("subbelongsToid")]

        //public string subbelongsToid { get; set; }
        //public SubjectBelongsTo subjectBelongsTo { get; }
        //public ICollection<StudentEnroll> StudentEnrolls { get; set; }
        public AttendanceStatus attendanceStatus { get; set; }

        //public virtual AttendanceDetails AttendanceDetails { get; set; }




    }
}
