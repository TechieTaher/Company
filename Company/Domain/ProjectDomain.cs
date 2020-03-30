using Company.Context;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Domain
{
    public class ProjectDomain : BaseContext
    {
        public List<Projects> GetByBusinessUnit(int businessUnitId)
        {
            return Projects.Where(t => t.BusinessUnitId == businessUnitId).ToList();
        }
        public void AddProject(Projects project)
        {
            Projects.Add(project);
            SaveChanges();
        }
        public List<Projects> GetProjects()
        {
            return Projects.ToList();
        }
    }
}
