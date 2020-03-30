using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeLeaves = new HashSet<EmployeeLeaves>();
            EmployeeProjects = new HashSet<EmployeeProjects>();
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        public long PhoneNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public int EmployeeType { get; set; }
        public int BusinessUnitId { get; set; }

        [ForeignKey(nameof(BusinessUnitId))]
        [InverseProperty(nameof(BusinessUnits.Employees))]
        public virtual BusinessUnits BusinessUnit { get; set; }
        [ForeignKey(nameof(EmployeeType))]
        [InverseProperty(nameof(ApplicationObjectName.Employees))]
        public virtual ApplicationObjectName EmployeeTypeNavigation { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeLeaves> EmployeeLeaves { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }
        [InverseProperty("ProjectManager")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
