using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    [Route("api/[controller]")]
    public class DesignationDataController : Controller
    {
        private IDesignation _IDesignation;
        public DesignationDataController(IDesignation IDesignation)
        {
            _IDesignation = IDesignation;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Designation> Get()
        {
            return _IDesignation.ShowAllDesignation();
        }
    }
}
