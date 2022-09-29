using LibraryManagement.Core.Contracts;
using LibraryManagement.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryManagement.UnitTests.Controller
{
    public class LibraryControllerTest
    {
        private readonly Mock<IAccountService> _accountServiceStub;

        public LibraryControllerTest()
        {
            _accountServiceStub = new Mock<IAccountService>();
        }

        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books()
        {
            //Arrange
              _accountServiceStub
                .Setup(x => x.GetAllBooksForCategory("UnitTesting"))
                .Returns(new List<string>()
                {
                    "The Art of Unit Testing",
                    "Test-Driven Development",
                    "Working Effectively with Legacy Code"
                });

            //Act
            var libraryController = new LibraryController(_accountServiceStub.Object);

            var actionResult = libraryController.GetAllBooksForCategory("UnitTesting");

            //Assert
            Assert.Equal((actionResult as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
        }
    }
}
