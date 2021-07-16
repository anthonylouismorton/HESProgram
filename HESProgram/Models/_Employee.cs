using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HESProgram.Models
{
    public partial class Employee
    {
        public string employeeFullName => LastName + ", " + FirstName;
    }
}