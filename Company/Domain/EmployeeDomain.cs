using Company.Context;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Domain
{
    public class EmployeeDomain : BaseContext
    {
        public void AddEmployee(Employees employee)
        {
            Employees.Add(employee);
            SaveChanges();
        }
        public List<Employees> GetByEmployeeName(string employeeName)
        {
            return Employees.Where<Employees>(c => c.EmployeeName.Contains(employeeName)).ToList();
        }
    }
}
