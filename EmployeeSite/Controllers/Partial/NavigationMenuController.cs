using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSite.Controllers.Partial
{
    public class NavigationMenuController : Controller
    {
        public IActionResult Index()
        {
            return PartialView("navigationMenu");
        }
    }
}