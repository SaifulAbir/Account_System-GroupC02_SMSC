using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Filters;
using GroupC02_SMSC.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{   
    [ValidateAccountantSession]
    public class StudentPaymentListController : Controller
    {
        // GET: /<controller>/
        private int Sid, Pid;
        private IStudentPaymentList _IStudentPaymentList;
        private IStudentPayment _IStudentPayment;
        public StudentPaymentListController(IStudentPaymentList IStudentPaymentList, IStudentPayment IStudentPayment)
        {
            
            _IStudentPaymentList = IStudentPaymentList;
            _IStudentPayment = IStudentPayment;
        }

        [HttpGet]
        public IActionResult AllPaymentsList()
        {

            return View();

        }

        public IActionResult LoadAllPayments()
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

                var v = _IStudentPaymentList.ShowAllPayments(sortColumn, sortColumnDir, searchValue);
                recordsTotal = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult AllPaymentsByStudent()
        {

            return View();

        }

        public IActionResult LoadAllPaymentsByStudent()
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

                var v = _IStudentPaymentList.ShowAllPaymentsByStudent(sortColumn, sortColumnDir, searchValue);
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
        public IActionResult AllStudentPayments(String id)
        {


            Sid = Convert.ToInt32(id);
            var x = _IStudentPaymentList.ShowAllPaymentsStudent(Sid);

            return View(x);
        }
        public IActionResult PaymentDashboard(string id)
        {
            Pid = Convert.ToInt32(id);
            var detailsBooking = _IStudentPayment.GetTotalPayment(Pid);



            return View(detailsBooking);
        }



    }
}
