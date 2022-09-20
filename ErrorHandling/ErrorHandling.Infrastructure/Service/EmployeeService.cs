using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorHandling.Core.Contract.Service;
using ErrorHandling.Core.Exceptions;

namespace ErrorHandling.Infrastructure.Service
{
    public class EmployeeService : IEmployee
    {
        public Task<int> VerifyEmployeeExist(int employeeId)
        {
            throw employeeId switch
            {
                0 => new AppException("Input request is invalid"),
                1 => new DuplicateException("Employee exits",new Exception("Emplyee already existed with this Id")),
                _ => new ArgumentOutOfRangeException()
            };
        }
    }
}
