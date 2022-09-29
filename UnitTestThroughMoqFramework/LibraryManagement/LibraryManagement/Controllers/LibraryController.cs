using LibraryManagement.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public LibraryController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(Name = "books")]
        public IActionResult GetAllBooksForCategory(string categoryId)
        {
            var result =  _accountService.GetAllBooksForCategory(categoryId);
            return Ok(result);
        }
    }
}
