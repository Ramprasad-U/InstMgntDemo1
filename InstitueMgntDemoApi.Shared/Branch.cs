using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InstitueMgntDemoApiData
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }

    }
}
