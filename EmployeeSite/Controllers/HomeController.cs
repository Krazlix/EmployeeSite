using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeSite.Models;
using Microsoft.AspNetCore.Http;
using EmployeeSite.Data;
using EmployeeSite.ViewModelBuilders;
using EmployeeSite.ViewModels;

namespace EmployeeSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.Session.GetString("_userName");
            return View();
        }

        public IActionResult Schedule()
        {
            ViewData["User"] = HttpContext.Session.GetString("_userName");

            ScheduleViewModel scheduleViewModel = new ScheduleViewModelBuilder().GetScheduleViewModel();

            return View(scheduleViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
