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
    public class AllFeeController : Controller
    {
        // GET: /<controller>/
       
        private IAllFee _IAllFee;

        public AllFeeController(IAllFee IAllFee)
        {
            _IAllFee = IAllFee;
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AllFee());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(AllFee AllFee)
        {


            AllFee objfee = new AllFee
            {

                FeeID = AllFee.FeeID,
                FeeName = AllFee.FeeName,
                FeeAmount = AllFee.FeeAmount,
                FeeTimeID = AllFee.FeeTimeID,
                ClassID = AllFee.ClassID,
            };

            _IAllFee.SaveFee(objfee);

            TempData["FeeMessage"] = "Fee Saved Successfully";
            ModelState.Clear();
            return View(new AllFee());

        }

        public IActionResult FeeList()
        {
            return View();
        }

        public IActionResult LoadFeeData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();

                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var v = _IAllFee.FeeList(sortColumn, sortColumnDir, searchValue);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
