using Company.Context;
using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Domain
{
    public class BusinessUnitDomain:BaseContext
    {
        public List<BusinessUnits> GetBusinessUnits()
        {
            return BusinessUnits.ToList();
        }
    }
}
