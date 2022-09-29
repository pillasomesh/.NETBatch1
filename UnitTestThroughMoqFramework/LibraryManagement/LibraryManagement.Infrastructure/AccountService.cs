﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.Contracts;

namespace LibraryManagement.Infrastructure
{
    public class AccountService: IAccountService
    {
        private IBookService _bookService;
        private IEmailSender _emailSender;

        public AccountService(IBookService bookService, IEmailSender emailSender)
        {
            _bookService = bookService;
            _emailSender = emailSender;
        }

        public IEnumerable<string> GetAllBooksForCategory(string categoryId)
        {
            var allBooks = _bookService.GetBooksForCategory(categoryId);
            return allBooks;
        }

        public string GetBookISBN(string categoryId, string searchTerm)
        {
            var allBooks = _bookService.GetBooksForCategory(categoryId);

            var foundBook = allBooks
                .Where(x => x.ToUpper().Contains(searchTerm.ToUpper()))
                .FirstOrDefault();
            if (foundBook == null)
            {
                return string.Empty;
            }

            return _bookService.GetISBNFor(foundBook);
        }

        public void SendEmail(string emailAddress, string bookTitle)
        {
            string subject = "Awesome Book";
            string body = $"Hi,\n\nThis book is awesome: {bookTitle}.\nCheck it out.";

            _emailSender.SendEmail(emailAddress, subject, body);
        }
    }
}
