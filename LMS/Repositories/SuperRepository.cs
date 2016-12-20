using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Repositories
{
    public class SuperRepository
    {
        public ApplicationDbContext context { get; set; }

        public SuperRepository()
        {
            context = new ApplicationDbContext();
        }

        internal IEnumerable<ClassUnit> GetClassUnits()
        {
            var classunits = context.MyClassUnit;
            return classunits;
        }
    }
}