using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GroupC02_SMSC.Models;
using Microsoft.AspNetCore.Http;
using GroupC02_SMSC.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    [ValidateUserSession]
    public class StudentController : Controller
    {

        // GET: /<controller>/
        private IStudentPayment _IStudentPayment;
        //private ITotalbilling _ITotalbilling;
        public StudentController(IStudentPayment IStudentPayment)
        {
            _IStudentPayment = IStudentPayment;
            //_ITotalbilling = ITotalbilling;
        }

        public IActionResult Dashboard()
        {
            var detailsBooking = _IStudentPayment.GetTotalPayment(Convert.ToInt32(HttpContext.Session.GetString("UserID")));



            return View(detailsBooking);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
