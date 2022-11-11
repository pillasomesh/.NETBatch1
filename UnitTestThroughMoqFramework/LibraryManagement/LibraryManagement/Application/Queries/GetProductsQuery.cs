using LibraryManagement.Application.Models;
using MediatR;

namespace LibraryManagement.Application.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
