using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class BusinessUnits
    {
        public BusinessUnits()
        {
            Employees = new HashSet<Employees>();
            Projects = new HashSet<Projects>();
        }

        [Key]
        public int BusinessUnitId { get; set; }
        [StringLength(50)]
        public string BusinessUnitName { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("BusinessUnit")]
        public virtual ICollection<Employees> Employees { get; set; }
        [InverseProperty("BusinessUnit")]
        public virtual ICollection<Projects> Projects { get; set; }
    }
}
