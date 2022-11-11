using LibraryManagement.Application.Models;
using LibraryManagement.DataStore;
using MediatR;

namespace LibraryManagement.Application.Queries
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken) => await _fakeDataStore.GetAllProducts();
    }
}
