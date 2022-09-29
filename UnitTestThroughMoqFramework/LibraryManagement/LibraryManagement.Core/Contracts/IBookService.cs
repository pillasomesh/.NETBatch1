using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Contracts
{
    public interface IBookService
    {
        string GetISBNFor(string bookTitle);
        IEnumerable<string> GetBooksForCategory(string categoryId);
    }

}
