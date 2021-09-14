using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InstitueMgntDemoApiData
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public Gender EmpGender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
