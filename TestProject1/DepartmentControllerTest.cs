using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstitueMgntDemoApi.Controllers;
using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApiData;
using InstitueMgntDemoApi;
using Moq;
using Xunit;
using Microsoft.OpenApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class DepartmentControllerTest
    {
        DepartmentController _controller;
        DepartmentServiceFake _service;

        public DepartmentControllerTest()
        {
            _service = new DepartmentServiceFake();
            _controller = new DepartmentController(_service);
        }
        [Fact]
        public void Get_WhenCalled_DeptList_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetDepartments();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetDepartments()
        {
            // Act
            var okResult = _controller.GetDepartments();
            var result = okResult.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Department>>(result.Value);
            Assert.Equal(2, items.Count);
        }
        [Fact]
        public void Get_whenCalled_DeptById_ResultsOkResult()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetDepartmentById(Testdeptid).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_whenCalled_DeptById_Results_NotFound()
        {
            //Arrange
            int Testdeptid = 100;
            //Act
            var notFound = _controller.GetDepartmentById(Testdeptid).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetDeptById()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetDepartmentById(Testdeptid).Result;//.Result.Value;
            var result = okResult.Result as OkObjectResult;
            //Assert
            var Items = Assert.IsType<Department>(result.Value);
            Assert.Equal(Testdeptid, (result.Value as Department).DepartmentId);
        }
    }

}

