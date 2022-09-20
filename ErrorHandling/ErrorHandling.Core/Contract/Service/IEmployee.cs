using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorHandling.Core.Contract.Service
{
    public interface IEmployee
    {
        Task<int> VerifyEmployeeExist(int employeeId);
    }
}
