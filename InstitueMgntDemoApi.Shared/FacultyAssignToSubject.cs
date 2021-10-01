using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitueMgntDemoApiData
{
    public class FacultyAssignToSubject
    {
        [Key]
        public int Id { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }
        [ForeignKey("SubjectBelongsToId")]
        public int SubjectBelongsToId { get; set; }
        public SubjectBelongsTo SubjectBelongsTo { get; set; }
        public Section Section { get; set; }
        




    }
}
