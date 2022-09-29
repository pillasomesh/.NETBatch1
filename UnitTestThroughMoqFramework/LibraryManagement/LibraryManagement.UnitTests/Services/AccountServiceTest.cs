using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.Contracts;
using LibraryManagement.Infrastructure;
using Moq;

namespace LibraryManagement.UnitTests.Services
{
    public class AccountServiceTest
    {

        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books()
        {
            //Arrange
            var bookServiceStub = new Mock<IBookService>();

            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
                    "The Art of Unit Testing",
                    "Test-Driven Development",
                    "Working Effectively with Legacy Code"
                });

            //Act
            var accountService = new AccountService(bookServiceStub.Object, null);

            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");

            //Assert
            Assert.Equal(3, result.Count());
           // Assert.
        }

        [Fact]
        public void GetBookISBN_founds_the_correct_book_for_search_term()
        {
            //Arrange
            var bookServiceStub = new Mock<IBookService>();
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
                    "The Art of Unit Testing",
                    "Test-Driven Development",
                    "Working Effectively with Legacy Code"
                });
            bookServiceStub
                .Setup(x => x.GetISBNFor("The Art of Unit Testing"))
                .Returns("0-9020-7656-6");
            //Act
            var accountService = new AccountService(bookServiceStub.Object, null);

            string result = accountService.GetBookISBN("UnitTesting", "art");
            //Assert
            Assert.Equal("0-9020-7656-6", result);
        }
        [Fact]
        public void SendEmail_sends_email_with_correct_content()
        {
            //1
            var emailSenderMock = new Mock<IEmailSender>();

            //2
            var accountService = new AccountService(null, emailSenderMock.Object);
            //3
            accountService.SendEmail("test@gmail.com", "Test - Driven Development");
            //4
            emailSenderMock.Verify(x => x.SendEmail("test@gmail.com", "Awesome Book", $"Hi,\n\nThis book is awesome: Test - Driven Development.\nCheck it out."), Times.Once);
        }
    }
}
