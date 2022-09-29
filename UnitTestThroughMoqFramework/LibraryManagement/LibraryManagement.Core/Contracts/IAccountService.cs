using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Contracts
{
    public interface IAccountService
    {
        IEnumerable<string> GetAllBooksForCategory(string categoryId);
        string GetBookISBN(string categoryId, string searchTerm);
        void SendEmail(string emailAddress, string bookTitle);
    }
}
