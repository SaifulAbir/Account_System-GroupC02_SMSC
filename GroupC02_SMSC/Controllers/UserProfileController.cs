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
    public class UserProfileController : Controller
    {
        IRegistration _IRepository;
        public UserProfileController(IRegistration IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            try
            {
                var profile = _IRepository.Userinformation(Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                return View(profile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        [HttpGet]
        public IActionResult Edit()
        {
            try
            {
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserID")))
                {
                    return RedirectToAction("ViewAllVenues", "AllVenue");
                }

                Registration EquipmentEdit = _IRepository.GetStudentByID(Convert.ToInt32(HttpContext.Session.GetString("UserID")));

                return View("Edit", EquipmentEdit);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Registration Registration)
        {


            Registration objEqu = new Registration
            {

                ID = Registration.ID,
                Name = Registration.Name,
                Address = Registration.Address,
                EmailID = Registration.EmailID,

                Birthdate = Registration.Birthdate,
                Gender = Registration.Gender,
                Mobileno = Registration.Mobileno,
                Username = Registration.Username,
                ClassID = Registration.ClassID
            };

            _IRepository.UpdateStudent(objEqu);

            TempData["UpdateMessage"] = "Profile Updated Successfully";
            //ModelState.Clear();
            return View(new Registration());



        }


    }
}
