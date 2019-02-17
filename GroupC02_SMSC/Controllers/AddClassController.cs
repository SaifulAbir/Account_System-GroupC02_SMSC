using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupC02_SMSC.Interface;
using GroupC02_SMSC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroupC02_SMSC.Controllers
{
    public class AddClassController : Controller
    {
        
            private readonly IHostingEnvironment _environment;
            private IAddClass _IAddClass;

            public AddClassController(IAddClass IAddClass, IHostingEnvironment hostingEnvironment)
            {
                _IAddClass = IAddClass;
                _environment = hostingEnvironment;
            }

            [HttpGet]
            public IActionResult Add()
            {
                return View(new AddClass());
            }

            /// <summary>
            /// Inserting Venue
            /// </summary>
            /// <param name="Venue"></param>
            /// <returns></returns>
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Add(AddClass AddClass)
            {
                

                    AddClass objvenue = new AddClass
                    {
                        
                        ClassID = AddClass.ClassID,
                        ClassName = AddClass.ClassName,
                       
                        
                    };

                    _IAddClass.SaveClass(objvenue);

                    TempData["ClassMessage"] = "Class Saved Successfully";
                    ModelState.Clear();
                    return View(new AddClass());

            }
        public IActionResult ClassList()
        {
            return View();
        }

        public IActionResult LoadClassData()
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

                var v = _IAddClass.ClassList(sortColumn, sortColumnDir, searchValue);
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
