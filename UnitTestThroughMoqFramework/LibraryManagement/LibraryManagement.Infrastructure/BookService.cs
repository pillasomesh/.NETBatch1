using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.Contracts;

namespace LibraryManagement.Infrastructure
{
    public class BookService : IBookService
    {
        public IEnumerable<string> GetBooksForCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public string GetISBNFor(string bookTitle)
        {
            throw new NotImplementedException();
        }
    }
}
