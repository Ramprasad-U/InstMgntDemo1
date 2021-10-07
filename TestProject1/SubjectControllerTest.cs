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
    public class SubjectControllerTest
    {
        SubjectController _controller;
        SubjectServiceFake _service;
        public SubjectControllerTest()
        {
            _service = new SubjectServiceFake();
            _controller = new SubjectController(_service);
        }

        #region "GET_SUBJECT_BYID"
        //GetSubjectById
        [Fact]
        public void Get_whenCalled_SubjectById_ResultsOkResult()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetSubjectById(Testdeptid).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_whenCalled_SubjectById_Results_NotFound()
        {
            //Arrange
            int Testdeptid = 100;
            //Act
            var notFound = _controller.GetSubjectById(Testdeptid).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetSubjectById()
        {
            //Arrange
            int Testdeptid = 1;
            //Act
            var okResult = _controller.GetSubjectById(Testdeptid).Result;//.Result.Value;
            var result = okResult.Result as OkObjectResult;
            //Assert
            var Items = Assert.IsType<Subject>(result.Value);
            Assert.Equal(Testdeptid, (result.Value as Subject).SubjectId);
        }
        #endregion

        #region "GET_SUBJECT_BYNAME"
        //GetSubjectById
        [Fact]
        public void Get_whenCalled_SubjectByName_ResultsOkResult()
        {
            //Arrange
            string TestsubName = "MATHS";
            //Act
            var okResult = _controller.GetSubjectByName(TestsubName).Result;
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_whenCalled_SubjectByName_Results_NotFound()
        {
            //Arrange
            string TestsubName = "Hello";
            //Act
            var notFound = _controller.GetSubjectByName(TestsubName).Result;
            //Assert
            Assert.IsType<NotFoundResult>(notFound.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetSubjectByName()
        {
            //Arrange
            string TestsubName = "MATHS";
            //Act
            var okResult = _controller.GetSubjectByName(TestsubName).Result;//.Result.Value;
            var result = okResult.Result as OkObjectResult;
            //Assert
            var Items = Assert.IsType<Subject>(result.Value);
            Assert.Equal(TestsubName, (result.Value as Subject).SubjectName);
        }

        #endregion

        #region "Create Subject"
        //Add
        [Fact]
        public void Add_validobjpass_Returns_ResponseCreateAtActionResult()
        {
            //Arrange
            var sub = new Subject()
            {
                SubjectId = 3,
                SubjectCode = "CHE03",
                SubjectName ="Chemistry"
            };
            //Act
            var createResp = _controller.CreateSubject(sub).Result;
            //Assert
            Assert.IsType<CreatedAtActionResult>(createResp.Result);
        }
        [Fact]
        public void Add_Invalidobjpass_Returns_BadRequest()
        {
            //Arrange
            var sub = new Subject()
            {
                SubjectId = 3,
                SubjectCode = "CHE03",
                //SubjectName = "Chemistry"
            };
            _controller.ModelState.AddModelError("SubjectName", "Required");
            //Act
            var badRequest = _controller.CreateSubject(sub).Result;
            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }
        [Fact]
        public void Add_validobjPass_Returns_ResponseHasCreatedItem()
        {
            var sub = new Subject()
            {
                SubjectId = 3,
                SubjectCode = "CHE03",
                SubjectName = "Chemistry"
            };
            var createResponse = _controller.CreateSubject(sub).Result;// as CreatedAtActionResult;
            var result = createResponse.Result as CreatedAtActionResult;
            var item = result.Value as Subject;
            //Assert
            Assert.IsType<Subject>(item);
            Assert.Equal("Chemistry", item.SubjectName);

        }
        #endregion

        #region "Get_Subject_List"
        [Fact]
        public void Get_WhenCalled_Subject_List_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetSubjects();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_GetSubjects()
        {
            // Act
            var okResult = _controller.GetSubjects();
            var result = okResult.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Subject>>(result.Value);
            Assert.Equal(2, items.Count);
        }
        #endregion

    }

}
