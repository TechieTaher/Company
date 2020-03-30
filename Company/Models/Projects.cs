using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class Projects
    {
        public Projects()
        {
            EmployeeProjects = new HashSet<EmployeeProjects>();
        }

        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime DeadLine { get; set; }
        public int Budget { get; set; }
        public int ProjectManagerId { get; set; }
        public int BusinessUnitId { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(BusinessUnitId))]
        [InverseProperty(nameof(BusinessUnits.Projects))]
        public virtual BusinessUnits BusinessUnit { get; set; }
        [ForeignKey(nameof(ProjectManagerId))]
        [InverseProperty(nameof(Employees.Projects))]
        public virtual Employees ProjectManager { get; set; }
        [ForeignKey(nameof(Status))]
        [InverseProperty(nameof(ApplicationObjectName.Projects))]
        public virtual ApplicationObjectName StatusNavigation { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
