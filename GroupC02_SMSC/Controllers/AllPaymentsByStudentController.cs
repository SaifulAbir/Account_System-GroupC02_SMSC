using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Filters;
using GroupC02_SMSC.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    [ValidateUserSession]
    public class AllPaymentsByStudentController : Controller
    {
        // GET: /<controller>/
        private IStudentPayment _IStudentPayment;
        private IStudentPaymentList _IStudentPaymentList;
        public AllPaymentsByStudentController(IStudentPayment IStudentPayment, IStudentPaymentList IStudentPaymentList)
        {
            _IStudentPayment = IStudentPayment;
            _IStudentPaymentList = IStudentPaymentList;
        }

        //[HttpGet]
        public IActionResult AllPaymentsByStudent()
        {
            
            var detailsBooking = _IStudentPayment.GetTotalPayment(Convert.ToInt32(HttpContext.Session.GetString("UserID")));
            
               
            
                return View(detailsBooking);
                                               
            
        }

        

        public IActionResult LoadAllBookings()
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

                var v = _IStudentPayment.ShowTotalPay(sortColumn, sortColumnDir, searchValue, Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        //[HttpGet]
        public IActionResult AllPaymentsList()
        {

            return View();

        }

        
    }
}
