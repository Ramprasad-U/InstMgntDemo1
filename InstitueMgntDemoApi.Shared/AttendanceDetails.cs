using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InstitueMgntDemoApiData
{
    public class AttendanceDetails
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public int subBelongsId { get; set; }
        [ForeignKey("subBelongsId")]
        public SubjectBelongsTo subjectBelongsTo { get; set; }
        //public List<Attendance> Attendances { get; set; }
        //public virtual Attendance Attendance { get; set; }
    }
}
