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
        #region "GetDepartmentList"
        //Get DepartList
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
        #endregion

        #region "GetDepById"
        //GetDepartmentById
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
        #endregion

        #region "createDepartment"
        //Add
        [Fact]
        public void Add_validobjpass_Returns_ResponseCreateAtActionResult()
        {
            //Arrange
            var dep = new Department()
            {
                DepartmentId = 3,
                DepartmentName = "accounts"
            };
            //Act
            var createResp = _controller.CreateDepartment(dep).Result;
            //Assert
            Assert.IsType<CreatedAtActionResult>(createResp.Result);
        }
        [Fact]
        public void Add_Invalidobjpass_Returns_BadRequest()
        {
            //Arrange
            Department dep = new Department()
            {
                DepartmentId = 3,

            };
            _controller.ModelState.AddModelError("DepartmentName", "Required");
            //Act
            var badRequest = _controller.CreateDepartment(dep).Result;
            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }
        [Fact]
        public void Add_validobjPass_Returns_ResponseHasCreatedItem()
        {
            var dep = new Department()
            {
                DepartmentId = 4,
                DepartmentName = "Operations"
            };
            var createResponse = _controller.CreateDepartment(dep).Result;// as CreatedAtActionResult;
            var result = createResponse.Result as CreatedAtActionResult;
            var item = result.Value as Department;
            //Assert
            Assert.IsType<Department>(item);
            Assert.Equal("Operations", item.DepartmentName);

        }
        #endregion

        #region "Get DepByName"
        //GetByName
        [Fact]
        public void Get_whenCalled_DeptByName_ResultsOkResult()
        {
            //Arrange
            string TestdeptName = "admin";
            //Act
            var okResult = _controller.GetDepartmentByName(TestdeptName).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_whenCalled_DeptByName_Results_NotFound()
        {
            //Arrange
            string TestdeptName = "Manager";
            //Act
            var notFound = _controller.GetDepartmentByName(TestdeptName).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetDeptByName()
        {
            //Arrange
            string TestdeptName = "admin";
            //Act
            var okResult = _controller.GetDepartmentByName(TestdeptName).Result;//.Result.Value;
            var result = okResult.Result as OkObjectResult;
            //Assert
            var Items = Assert.IsType<Department>(result.Value);
            Assert.Equal(TestdeptName, (result.Value as Department).DepartmentName);
        }
        #endregion
    }

}

