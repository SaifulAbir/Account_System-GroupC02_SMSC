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
    public class AddClassDataController : Controller
    {
        private IAddClass _IAddClass;
        public AddClassDataController(IAddClass IAddClass)
        {
            _IAddClass = IAddClass;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<AddClass> Get()
        {
            return _IAddClass.ShowAllClass();
        }

    }
}