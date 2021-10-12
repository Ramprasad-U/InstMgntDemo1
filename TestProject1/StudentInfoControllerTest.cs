using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstitueMgntDemoApi.Controllers;
using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
using Microsoft.AspNetCore.Mvc;
using Xunit;


namespace TestProject1
{
    public class StudentInfoControllerTest
    {
        StudentController _controller;
        StudenServiceFake _service;
        public StudentInfoControllerTest()
        {
            _service = new StudenServiceFake();
            _controller = new StudentController(_service);
        }
        #region "Get_StudentInfo_List"
        [Fact]
        public void Get_WhenCalled_Subject_List_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetStudentInfos();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetSubjects()
        {
            // Act
            var okResult = _controller.GetStudentInfos();
            var result = okResult.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<StudentInfo>>(result.Value);
            Assert.Equal(3, items.Count);
        }
        #endregion


        #region "GET_SUBJECT_BYID"
        //GetSubjectById
        [Fact]
        public void Get_whenCalled_StudentInfoById_ResultsOkResult()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetStudentInfoById(Testdeptid).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_whenCalled_StudentById_Results_NotFound()
        {
            //Arrange
            int Testdeptid = 10;
            //Act
            var notFound = _controller.GetStudentInfoById(Testdeptid).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetStudentById()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetStudentInfoById(Testdeptid).Result;//.Result.Value;
            var result = okResult.Result as OkObjectResult;
            //Assert
            var Items = Assert.IsType<StudentInfo>(result.Value);
            Assert.Equal(Testdeptid, (result.Value as StudentInfo).StudentInfoId);
        }
        #endregion


    }
}
