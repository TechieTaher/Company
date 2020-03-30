using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class EmployeeProjects
    {
        [Key]
        public int EmployeeProjectId { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.EmployeeProjects))]
        public virtual Employees Employee { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty(nameof(Projects.EmployeeProjects))]
        public virtual Projects Project { get; set; }
    }
}
