using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork.Entities.Exceptions
{
    public class EmployeeCapacityException : Exception
    {
        public EmployeeCapacityException(string message)
        : base(message)
        { }
    }
}
