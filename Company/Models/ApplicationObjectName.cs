using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class ApplicationObjectName
    {
        public ApplicationObjectName()
        {
            Employees = new HashSet<Employees>();
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int ApplicationObjectNameId { get; set; }
        [Required]
        [Column("ApplicationObjectName")]
        [StringLength(50)]
        public string ApplicationObjectName1 { get; set; }
        public int ApplicationObjectTypeId { get; set; }

        [ForeignKey(nameof(ApplicationObjectTypeId))]
        [InverseProperty("ApplicationObjectName")]
        public virtual ApplicationObjectType ApplicationObjectType { get; set; }
        [InverseProperty("EmployeeTypeNavigation")]
        public virtual ICollection<Employees> Employees { get; set; }
        [InverseProperty("StatusNavigation")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
