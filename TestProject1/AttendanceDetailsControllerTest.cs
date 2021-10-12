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
    public class AttendanceDetailsControllerTest
    {
        AttendanceDetailsController _controller;
        AttendanceDetailsServiceFake _service;
        public AttendanceDetailsControllerTest()
        {
            _service = new AttendanceDetailsServiceFake();
            _controller = new AttendanceDetailsController(_service);
        }
        #region "Get_AttendanceDetails_List"
        [Fact]
        public void Get_WhenCalled_GetAttendanceDetails_List_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAttendanceDetails();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetAttendanceDetails()
        {
            // Act
            var okResult = _controller.GetAttendanceDetails();
            var result = okResult.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<AttendanceDetails>>(result.Value);
            Assert.Equal(3, items.Count);
        }
        #endregion

        #region "GetAttendanceDetails_BYID"
        //GetSubjectById
        [Fact]
        public void Get_whenCalled_GetAttendanceDetailsById_ResultsOkResult()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetAttendanceDetailsById(Testdeptid).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_whenCalled_GetAttendanceDetailsById_Results_NotFound()
        {
            //Arrange
            int Testdeptid = 10;
            //Act
            var notFound = _controller.GetAttendanceDetailsById(Testdeptid).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound);
        }
        [Fact]
        public void Get_WhenCalled_GetAttendanceDetailsById()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetAttendanceDetailsById(Testdeptid).Result;//.Result.Value;
            var result = okResult as OkObjectResult;
            //Assert
            var Items = Assert.IsType<AttendanceDetails>(result.Value);
            Assert.Equal(Testdeptid, (result.Value as AttendanceDetails).id);
        }
        #endregion

        #region "createAttendance"
        //Add
        [Fact]
        public void Add_validobjpass_Returns_ResponseCreateAtActionResult()
        {
            //Arrange
            var attenddetails = new AttendanceDetails()
            {
                id = 4,
                date = new DateTime(2021, 10, 05),
                subBelongsId = 1

            };
            //Act
            var createResp = _controller.CreateattendanceDetails(attenddetails).Result;
            //Assert
            Assert.IsType<CreatedAtActionResult>(createResp.Result);
        }
        [Fact]
        public void Add_Invalidobjpass_Returns_BadRequest()
        {
            //Arrange
            var attenddetails = new AttendanceDetails()
            {
                id = 4,
                date = new DateTime(2021, 10, 05),
                //subBelongsId = 1

            };
            _controller.ModelState.AddModelError("subBelongsId", "Required");
            //Act
            var badRequest = _controller.CreateattendanceDetails(attenddetails).Result;
            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }
        [Fact]
        public void Add_validobjPass_Returns_ResponseHasCreatedItem()
        {
            var attenddetails = new AttendanceDetails()
            {
                id = 4,
                date = new DateTime(2021,10,05),
                subBelongsId = 1
                
            };
            var createResponse = _controller.CreateattendanceDetails(attenddetails).Result;// as CreatedAtActionResult;
            var result = createResponse.Result as CreatedAtActionResult;
            var item = result.Value as AttendanceDetails;
            //Assert
            Assert.IsType<AttendanceDetails>(item);
            Assert.Equal(4, item.id);

        }
        #endregion

    }
}
