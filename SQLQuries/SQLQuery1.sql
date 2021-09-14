


use InstMgntDemoDB;
select * from Branches;
select * from [dbo].[StudentEnrolls]
select * from [dbo].[SubjectBelongsTos];
select * from [dbo].[Subjects] where SubjectId = 3;

--update Subjects set SubjectCode = 'OOP102' where SubjectId = 3

select * from [dbo].[FacultyAssignToSubjects];
select * from [dbo].[Employees]
select * from [dbo].[Subjects];

select StudentEnrollid from StudentEnrolls se join SubjectBelongsTos sb on se.BranchCode = sb.BranchCode and se.Semester = sb.Sem

select * from SubjectBelongsTos sb join StudentEnrolls se on se.BranchCode = sb.BranchCode and se.Semester = sb.Sem


select * from [FacultyAssignToSubjects] fs join [Employees] e on fs.Empid = e.EmpId
