﻿// <auto-generated />
using System;
using InstitueMgntDemoApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InstitueMgntDemoApi.Services.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210912161937_StudentEnrollsLatestchangesTOEnrollId")]
    partial class StudentEnrollsLatestchangesTOEnrollId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InstitueMgntDemoApiData.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            BranchCode = "CSE",
                            BranchName = "Computer Science Engineering"
                        },
                        new
                        {
                            BranchId = 2,
                            BranchCode = "MEC",
                            BranchName = "Mechanical Engineering"
                        },
                        new
                        {
                            BranchId = 3,
                            BranchCode = "ECE",
                            BranchName = "Electronic Communication Engineering"
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Faculty"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "Administator"
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmpEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpGender")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            DepartmentId = 1,
                            EmpEmail = "John@gmail.com",
                            EmpGender = 0,
                            EmpName = "John"
                        },
                        new
                        {
                            EmpId = 2,
                            DepartmentId = 2,
                            EmpEmail = "chris@gmail.com",
                            EmpGender = 0,
                            EmpName = "Chris"
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.FacultyAssignToSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("Section")
                        .HasColumnType("int");

                    b.Property<int>("SubjectBelongsToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.HasIndex("SubjectBelongsToId");

                    b.ToTable("FacultyAssignToSubjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmpId = 1,
                            Section = 0,
                            SubjectBelongsToId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmpId = 1,
                            Section = 0,
                            SubjectBelongsToId = 5
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.StudentEnroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("Section")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("StudentEnrollId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("StudentInfoId");

                    b.ToTable("StudentEnrolls");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BranchId = 1,
                            Section = 0,
                            Semester = 0,
                            StudentEnrollId = "21STUCSE00001",
                            StudentInfoId = 1
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.StudentInfo", b =>
                {
                    b.Property<int>("StudentInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBrith")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentInfoId");

                    b.ToTable("StudentInfos");

                    b.HasData(
                        new
                        {
                            StudentInfoId = 1,
                            DateOfBrith = new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Aurora@gmail.com",
                            Gender = 1,
                            Name = "Aurora"
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubjectId = 1,
                            SubjectCode = "CN201",
                            SubjectName = "Computer Networks"
                        },
                        new
                        {
                            SubjectId = 2,
                            SubjectCode = "MA100",
                            SubjectName = "Mathematics"
                        },
                        new
                        {
                            SubjectId = 3,
                            SubjectCode = "OOP102",
                            SubjectName = "ObjectOrientedPrograming"
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.SubjectBelongsTo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("Sem")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BranchId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectBelongsTos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            BranchId = 1,
                            Sem = 2,
                            SubjectId = 1
                        },
                        new
                        {
                            id = 2,
                            BranchId = 1,
                            Sem = 0,
                            SubjectId = 2
                        },
                        new
                        {
                            id = 3,
                            BranchId = 3,
                            Sem = 0,
                            SubjectId = 2
                        },
                        new
                        {
                            id = 4,
                            BranchId = 2,
                            Sem = 0,
                            SubjectId = 2
                        },
                        new
                        {
                            id = 5,
                            BranchId = 1,
                            Sem = 1,
                            SubjectId = 3
                        });
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.Employee", b =>
                {
                    b.HasOne("InstitueMgntDemoApiData.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.FacultyAssignToSubject", b =>
                {
                    b.HasOne("InstitueMgntDemoApiData.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InstitueMgntDemoApiData.SubjectBelongsTo", "SubjectBelongsTo")
                        .WithMany()
                        .HasForeignKey("SubjectBelongsToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("SubjectBelongsTo");
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.StudentEnroll", b =>
                {
                    b.HasOne("InstitueMgntDemoApiData.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InstitueMgntDemoApiData.StudentInfo", "StudentInfo")
                        .WithMany()
                        .HasForeignKey("StudentInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("StudentInfo");
                });

            modelBuilder.Entity("InstitueMgntDemoApiData.SubjectBelongsTo", b =>
                {
                    b.HasOne("InstitueMgntDemoApiData.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InstitueMgntDemoApiData.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Subject");
                });
#pragma warning restore 612, 618
        }
    }
}
