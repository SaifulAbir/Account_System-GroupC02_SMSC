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
    public class StudentUpdateController : Controller
    {
        // GET: /<controller>/
        private IRegistration _IEquipment;

        public StudentUpdateController(IRegistration IEquipment)
        {
           
            _IEquipment = IEquipment;
        }
        [HttpGet]
        public IActionResult Index(string id )
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ViewAllVenues", "AllVenue");
                }

                Registration EquipmentEdit = _IEquipment.GetStudentByID(Convert.ToInt32(id));

                return View("Index", EquipmentEdit);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Registration Registration)
        {

            
                Registration objEqu = new Registration
                {
                    
                    ID = Registration.ID,
                    Name = Registration.Name,
                    Address = Registration.Address,
                    EmailID = Registration.EmailID,

                    Birthdate = Registration.Birthdate,
                    Gender = Registration.Gender ,
                    Mobileno = Registration.Mobileno,
                    Username = Registration.Username,
                    ClassID = Registration.ClassID
                };

                _IEquipment.UpdateStudent(objEqu);

                TempData["UpdateMessage"] = "Profile Updated Successfully";
                //ModelState.Clear();
                return View(new Registration());
            
           

        }

    }
}
