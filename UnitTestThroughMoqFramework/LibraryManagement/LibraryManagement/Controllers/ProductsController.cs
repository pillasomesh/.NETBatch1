using LibraryManagement.Application.Commands;
using LibraryManagement.Application.Models;
using LibraryManagement.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            {
                await _mediator.Send(new AddProductCommand(product));
                return StatusCode(201);
            }
        }
    }
}
