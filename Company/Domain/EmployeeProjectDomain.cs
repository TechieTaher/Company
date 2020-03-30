using Company.Context;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Domain
{
    public class EmployeeProjectDomain : BaseContext
    {
        public void AddEmployeeProject(EmployeeProjects employeeProject)
        {
            EmployeeProjects.Add(employeeProject);
            SaveChanges();
        }
    }
}
