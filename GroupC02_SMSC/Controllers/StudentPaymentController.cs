using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Filters;
using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    [ValidateUserSession]
    public class StudentPaymentController : Controller
    {
        // GET: /<controller>/
        private IStudentPayment _IStudentPayment;
        private IAllFee _IAllFee;
        public StudentPaymentController(IStudentPayment IStudentPayment, IAllFee IAllFee)
        {
            _IStudentPayment = IStudentPayment;
            _IAllFee = IAllFee;
        }

        [HttpGet]
        public IActionResult StudentPayment()
        {

            //SetSlider();

            return View(new StudentPayment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StudentPayment(StudentPayment StudentPayment)
        {
            //if (ModelState.IsValid)
            // {

            PaymentDetails BD = new PaymentDetails
            {
                PaymentDate = StudentPayment.PaymentDate,
                Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                CreatedDate = DateTime.Now,
                PaymentApproval = "P"
            };

            var result = _IStudentPayment.BookEvent(BD);

            StudentPayment BV = new StudentPayment
            {
                FeeID = StudentPayment.FeeID,
                PaymentDate = StudentPayment.PaymentDate,
                CardNum = StudentPayment.CardNum,
                Pin = StudentPayment.Pin,
                Amount = StudentPayment.Amount,
                Createdby = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                CreatedDate = DateTime.Now,
                PaymentDetailID = result
            };

            var VenueID = _IStudentPayment.FeePayment(BV);

            HttpContext.Session.SetInt32("PaymentDetailID", result);

            if (result > 0)
            {
                //SetSlider();
                //ModelState.Clear();
                ViewData["PaymentMessage"] = "Amount Paid Successfully";
                //return View("Payment");
                return View(StudentPayment);
            }
            else
            {
                //SetSlider();
                //return View("Payment", Payment);
                return View(StudentPayment);
            }
            //}
            //else
            //{
            //SetSlider();
            // return View("Payment", Payment);
            //}
        }
    }
}
