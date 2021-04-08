using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DMP.Models;
using DMP.Enrichers;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DMP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OrganizationController : ControllerBase
    {
        private MyContext myContext;

        public OrganizationController(MyContext context)
        {
            myContext = context;
        }

        [HttpGet]
        public ActionResult<List<Organization>> Get()
        {
            List<Organization> organizations = myContext.Organizations.ToList();
            return Ok(organizations);
        }

        [HttpPost]
        public ActionResult Post(Organization organization)
        {
            myContext.Organizations.Add(organization);
            myContext.SaveChanges();
            return Ok(organization);
        }
    }
}