using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Core.Contracts;

namespace LibraryManagement.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
