using EmployeeSite.Data;
using EmployeeSite.Models;
using EmployeeSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.ViewModelBuilders
{
    public class ScheduleViewModelBuilder
    {
        public ScheduleViewModel GetScheduleViewModel()
        {
            DateTime startOfWeek = DateTime.Now.Date; //.AddDays(-Convert.ToInt32(DateTime.Now.DayOfWeek));
            List<Event> eventList = EventManager.GetWeekSchedule(/*Convert.ToInt32(HttpContext.Session.GetString("_userID"))*/2, startOfWeek);
            Dictionary<DayOfWeek, List<Event>> eventsDic = eventList.GroupBy(e => e.DateStart.DayOfWeek, e => e)
                                                            .ToDictionary(e => e.Key, e => e.ToList());

            return new ScheduleViewModel
            {
                Events = eventsDic,
                StartDate = startOfWeek,
                DaysOfWeek = GetDaysOfWeek(startOfWeek)
            };
        }

        private List<DayOfWeek> GetDaysOfWeek(DateTime startDate)
        {
            var daysOfWeek = new List<DayOfWeek>();
            
            for (var i = 0; i < 7; i++)
            {
                daysOfWeek.Add(startDate.DayOfWeek);
                startDate = startDate.AddDays(1);      
            }

            return daysOfWeek;
        } 

    }
}
