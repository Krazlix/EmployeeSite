using EmployeeSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.ViewModels
{
    public class ScheduleViewModel
    {
        public Dictionary<DayOfWeek, List<Event>> Events { get; set; }

        public DateTime StartDate { get; set; }

        public List<DayOfWeek> DaysOfWeek { get; set; }
    }
}
