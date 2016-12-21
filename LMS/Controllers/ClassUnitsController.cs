using LMS.Models;
using LMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class ClassUnitsController : ApiController
    {
       private readonly SuperRepository _repo;

        public ClassUnitsController ()
        {
            _repo = new SuperRepository();
        }

        // GET: api/ClassUnits
        public ICollection<ClassUnit> GetClassUnits()
        {
            var classunits = _repo.GetClassUnits().ToList();
            return classunits;
        }

    }
}
