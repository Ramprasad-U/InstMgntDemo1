using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitueMgntDemoApiData
{
    public class SubjectBelongsTo
    {
        public int id { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public Semester Sem { get; set; }

    }
}
