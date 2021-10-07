using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InstitueMgntDemoApiData;

namespace InstitueMgntDemoApi.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StudentEnroll> StudentEnrolls { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectBelongsTo> SubjectBelongsTos { get; set; }
        public DbSet<FacultyAssignToSubject> FacultyAssignToSubjects { get; set; }
        //Attendance Details
        public DbSet<AttendanceDetails> AttendanceDetails { get; set; }

        //Attendance
        public DbSet<Attendance> Attendances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Departments Table
            modelBuilder.Entity<Department>().HasData(
                new Department {
                    DepartmentId = 1,
                    DepartmentName = "Faculty" });
            modelBuilder.Entity<Department>().HasData(
                new Department {
                    DepartmentId = 2,
                    DepartmentName = "Administator" });

            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmpId = 1,
                EmpName = "John",
                EmpEmail = "John@gmail.com",
                EmpGender = Gender.Male,
                DepartmentId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmpId = 2,
                EmpName = "Chris",
                EmpEmail = "chris@gmail.com",
                EmpGender = Gender.Male,
                DepartmentId = 2
            });
            //Seed Subject Table
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubjectId =1,
                SubjectCode="CN201",
                SubjectName="Computer Networks"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubjectId = 2,
                SubjectCode = "MA100",
                SubjectName = "Mathematics"
            });
            modelBuilder.Entity<Subject>().HasData(new Subject
            {
                SubjectId = 3,
                SubjectCode = "OOP102",
                SubjectName = "ObjectOrientedPrograming"
            });
            //Seed Branch Table
            modelBuilder.Entity<Branch>().HasData(new Branch
            {
                BranchId=1,
                BranchCode="CSE",
                BranchName="Computer Science Engineering"
            });
            modelBuilder.Entity<Branch>().HasData(new Branch
            {
                BranchId = 2,
                BranchCode = "MEC",
                BranchName = "Mechanical Engineering"
            });
            modelBuilder.Entity<Branch>().HasData(new Branch
            {
                BranchId = 3,
                BranchCode = "ECE",
                BranchName = "Electronic Communication Engineering"
            });
            modelBuilder.Entity<SubjectBelongsTo>().HasData(new SubjectBelongsTo
            {
                id = 1,
                SubjectId = 1,
                Sem = Semester.SEM3,
                BranchId = 1
                
            });
            modelBuilder.Entity<SubjectBelongsTo>().HasData(new SubjectBelongsTo
            {
                id = 2,
                SubjectId = 2,
                Sem = Semester.SEM1,
                BranchId = 1

            });
            modelBuilder.Entity<SubjectBelongsTo>().HasData(new SubjectBelongsTo
            {
                id = 3,
                SubjectId = 2,
                Sem = Semester.SEM1,
                BranchId = 3

            });
            modelBuilder.Entity<SubjectBelongsTo>().HasData(new SubjectBelongsTo
            {
                id = 4,
                SubjectId = 2,
                Sem = Semester.SEM1,
                BranchId = 2

            });
            modelBuilder.Entity<SubjectBelongsTo>().HasData(new SubjectBelongsTo
            {
                id = 5,
                SubjectId = 3,
                Sem = Semester.SEM2,
                BranchId = 1

            });
            modelBuilder.Entity<StudentInfo>().HasData(new StudentInfo
            {
                StudentInfoId = 1,
                Name="Aurora",
                Email="Aurora@gmail.com",
                Gender=Gender.Female,
                DateOfBrith = new DateTime(1999, 10, 5)
            });
            modelBuilder.Entity<StudentEnroll>().HasData(new StudentEnroll
            {
                Id = 1,
                StudentEnrollId="21STUCSE00001",
                StudentInfoId = 1,
                BranchId = 1,
                Semester=Semester.SEM1,
                Section=Section.SEC01

            });
            modelBuilder.Entity<FacultyAssignToSubject>().HasData(new FacultyAssignToSubject
            {
                Id = 1,
                EmpId = 1,
                SubjectBelongsToId = 1,
                Section=Section.SEC01
            });
            modelBuilder.Entity<FacultyAssignToSubject>().HasData(new FacultyAssignToSubject
            {
                Id = 2,
                EmpId = 1,
                SubjectBelongsToId = 5,
                Section = Section.SEC01
            });

        }
    }

}
