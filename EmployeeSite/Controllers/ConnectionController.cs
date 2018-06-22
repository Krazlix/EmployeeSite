using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSite.Data;
using EmployeeSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSite.Controllers
{
    public class ConnectionController : Controller
    {
        public IActionResult Connection()
        {
            ViewBag.message = "user name not found";
            return View();
        }
        [HttpPost]
        public ActionResult Connect(Employee model)
        {
            
            if (model.Name != null)
            {
               EmployeeManager userManager = new EmployeeManager();
                 Employee newEmployee = new Employee();
                /*newEmployee.Name = "Emilien";
                newEmployee.Gender = true;
                newEmployee.Surname = "Sergeant";
                newEmployee.Role = "role 1";
                newEmployee.Email = "qsd@qsdf.fr";
                newEmployee.Password = "mdp";
                userManager.AddEmployee(newEmployee);*/
                newEmployee.Name = "Emilien";
                newEmployee.Password= "mdp";
               newEmployee = userManager.checkEmployeeConnection(newEmployee);

                ViewBag.message = newEmployee.Name;
                HttpContext.Session.SetString("_userName", newEmployee.Name);
                HttpContext.Session.SetString("_userID", newEmployee.EmployeeId.ToString());

                return RedirectToRoute("home", null); 
            }
                
            else
                return View("connection");
        }
    }
}