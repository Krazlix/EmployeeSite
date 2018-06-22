using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.Models
{
    public class Event
    {
        public int EmployeeId { get; set; }
        public int EquipeId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public String EventName { get; set; }
        public int HourDuration { get; set; }
        public int MinuteDuration { get; set; }
    }
}
