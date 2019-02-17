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
    public class AllFeeDataController : Controller
    {
        // GET: /<controller>/
        private IAllFee _IAllFee;
        public AllFeeDataController(IAllFee IAllFee)
        {
            _IAllFee = IAllFee;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<AllFee> Get()
        {
            return _IAllFee.ShowAllFee();
        }
    }
}
