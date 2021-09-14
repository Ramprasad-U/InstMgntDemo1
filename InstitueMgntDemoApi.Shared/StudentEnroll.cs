using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitueMgntDemoApiData
{
    public class StudentEnroll
    {
        [Key]
        public int Id { get; set; }
        public string StudentEnrollId { get; set; } 
        //yr+std+brncode+0001 = 21STDCSE0001, 21STDMEC001.......... 
        [ForeignKey("StudentInfoId")]
        public int StudentInfoId { get; set; }
        public StudentInfo StudentInfo { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public Semester Semester { get; set; }
        public Section Section { get; set; }


    }
}
