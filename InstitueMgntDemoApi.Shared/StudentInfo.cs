using System;
using System.ComponentModel.DataAnnotations;

namespace InstitueMgntDemoApiData
{
    public class StudentInfo
    {
        [Key]
        public int StudentInfoId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBrith { get; set; }

    }
}
