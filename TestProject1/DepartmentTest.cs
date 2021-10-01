using System;
using Xunit;
using Moq;
using InstitueMgntDemoApi;
using InstitueMgntDemoApiData;
using InstitueMgntDemoApi.Services;
using InstitueMgntDemoApi.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class DepartmentTest
    {
        //#region
        //public Mock<IDepartmentRepository> mock = new Mock<IDepartmentRepository>();
        //#endregion
        //[Fact]
        //public async void GetDepartmentslist()
        //{
        //    var departmentlst = new List<Department>()
        //    {new Department()
        //    {
        //        DepartmentId = 1,
        //        DepartmentName = "Faculty"
        //    },
        //     new Department()
        //    {
        //        DepartmentId = 2,
        //        DepartmentName = "Admin"
        //    }
        //    };
        //    mock.Setup(p => p.GetDepartments()).ReturnsAsync(departmentlst);
        //    DepartmentController dep = new DepartmentController(mock.Object);

        //    var result = await dep.GetDepartments();


        //    Assert.True(departmentlst.Equals(result));
        //}
        //[Fact]
        ////public async Task<IEnumerable<Department>> GetDepartment_Returns_Correct_Count()
        // public async Task GetDepartment_Returns_Correct_Count()
        // {
        //    //Arrange
        //    int count = 2;
        //    var fakedeparts = A.CollectionOfDummy<Department>(count).AsEnumerable();
        //    var datastore = A.Fake<IDepartmentRepository>();
        //    A.CallTo(() => datastore.GetDepartments()).Returns(Task.FromResult(fakedeparts));
        //    var contoller = new DepartmentController(datastore);

        //    //Act
        //    var actionResult = await contoller.GetDepartments();

        //    //Assert
        //    var result = actionResult.Result as OkObjectResult;
        //    //var result = Assert.IsType<OkObjectResult>(actionResult.Result);
        //    var returnDepartments = result as IEnumerable<Department>;
        //    Assert.Equal(count, returnDepartments.Count());
        //}
    }
}
