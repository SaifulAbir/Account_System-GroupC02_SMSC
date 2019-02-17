using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventApplicationCore.Library;
using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        ILogin _ILogin;

        public LoginController(ILogin ILogin)
        {
            _ILogin = ILogin;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(loginViewModel.Username) && !string.IsNullOrEmpty(loginViewModel.Password))
                {
                    var Username = loginViewModel.Username;
                    var password = EncryptionLibrary.EncryptText(loginViewModel.Password);

                    var result = _ILogin.ValidateUser(Username, password);

                    if (result != null)
                    {
                        if (result.ID == 0 || result.ID < 0)
                        {
                            ViewBag.errormessage = "Entered Invalid Username and Password";
                        }
                        else
                        {
                            var RoleID = result.RoleID;
                            remove_Anonymous_Cookies(); //Remove Anonymous_Cookies

                            HttpContext.Session.SetString("UserID", Convert.ToString(result.ID));
                            HttpContext.Session.SetString("RoleID", Convert.ToString(result.RoleID));
                            HttpContext.Session.SetString("Username", Convert.ToString(result.Username));
                            if (RoleID == 1)
                            {
                                return RedirectToAction("Dashboard", "Accountant");
                            }
                            else if (RoleID == 2)
                            {
                                return RedirectToAction("Dashboard", "Student");
                            }
                            else if (RoleID == 3)
                            {
                                return RedirectToAction("Dashboard", "Teacher");
                            }
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "Entered Invalid Username and Password";
                        return View();
                    }
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            try
            {
                CookieOptions option = new CookieOptions();

                if (Request.Cookies["AccountSystemChannel"] != null)
                {
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Append("AccountSystemChannel", "", option);
                }

                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
            catch (Exception)
            {
                throw;
            }

        }
        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            if (Request.Cookies["AccountSystemChannel"] != null)
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Append("AccountSystemChannel", "", option);
            }
        }
    }
}
