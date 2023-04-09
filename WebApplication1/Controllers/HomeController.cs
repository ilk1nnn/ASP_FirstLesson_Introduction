using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello From Index Action";
        }

        public IActionResult Index2()
        {
            return View();
        }

        public ViewResult Employees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    CityId = 1,
                    FirstName = "Huseyn",
                    LastName = "Abbasov"
                },
                new Employee
                {
                    Id = 2,
                    CityId = 1,
                    FirstName = "Ilkin",
                    LastName = "Suleymanov"
                },
                new Employee
                {
                    Id = 3,
                    CityId = 2,
                    FirstName = "Alirza",
                    LastName = "Zaidov"
                }
            };
            List<string> cities = new List<string> { "Baku", "Bern", "Stockholm" };
            var vm = new EmployeeViewModel
            {
                Employees = employees,
                Cities = cities
            };
            return View(vm);
        }


        public IActionResult Index4()
        {
            return Ok();
        }


        public IActionResult Index5()
        {
            return NotFound();
        }

        public IActionResult Index6()
        {
            return BadRequest();
        }

        public IActionResult Index7()
        {
            return Redirect("/home/index2");
        }

        public IActionResult Index8()
        {
            return RedirectToAction("employees");
        }

        public IActionResult Index9()
        {
            var routeValue = new RouteValueDictionary(new { action = "Employees", controller = "Home" });
            return RedirectToRoute(routeValue);
        }

        public JsonResult GetJson()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    CityId = 1,
                    FirstName = "Huseyn",
                    LastName = "Abbasov"
                },
                new Employee
                {
                    Id = 2,
                    CityId = 1,
                    FirstName = "Ilkin",
                    LastName = "Suleymanov"
                },
                new Employee
                {
                    Id = 3,
                    CityId = 2,
                    FirstName = "Alirza",
                    LastName = "Zaidov"
                }
            };
            return Json(employees);
        }


        public JsonResult Index10(int id=-1)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    CityId = 1,
                    FirstName = "Huseyn",
                    LastName = "Abbasov"
                },
                new Employee
                {
                    Id = 2,
                    CityId = 1,
                    FirstName = "Ilkin",
                    LastName = "Suleymanov"
                },
                new Employee
                {
                    Id = 3,
                    CityId = 2,
                    FirstName = "Alirza",
                    LastName = "Zaidov"
                }
            };
            if (id == -1)
            {
                return Json(employees);
            }
            else
            {
                var data = employees.FirstOrDefault(e => e.Id == id);
                return Json(data);
            }
        }

    }
}
