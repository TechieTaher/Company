using Company.Context;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class EmployeeLeaveDomain : BaseContext
    {
        public void AddEmployeeLeave(EmployeeLeaves employeeLeave)
        {
            EmployeeLeaves.Add(employeeLeave);
            SaveChanges();
        }
    }
}
