using LibraryManagement.Application.Models;
using MediatR;

namespace LibraryManagement.Application.Commands
{
    public record AddProductCommand(Product Product) : IRequest;
}
