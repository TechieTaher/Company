using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    public partial class ApplicationObjectType
    {
        public ApplicationObjectType()
        {
            ApplicationObjectName = new HashSet<ApplicationObjectName>();
        }

        [Key]
        public int ApplicationObjectTypeId { get; set; }
        [StringLength(50)]
        public string ApplicationObjectTypeName { get; set; }

        [InverseProperty("ApplicationObjectType")]
        public virtual ICollection<ApplicationObjectName> ApplicationObjectName { get; set; }
    }
}
