using EmployeeSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.Data
{
    public static class EventManager
    {
        private const string connectionString = "Server=localhost; Database=project_intra; Trusted_Connection=True; MultipleActiveResultSets=true";

        public static List<Event> GetWeekSchedule(int employeeId,DateTime dateStart)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {              
                SqlCommand cmd = new SqlCommand("getSchedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeID", employeeId);
                cmd.Parameters.AddWithValue("@Date", dateStart);

                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Event> timetable = new List<Event>();
                        Event newEvent;
                        while (reader.Read())
                        {
                            newEvent = new Event();
                            newEvent.EquipeId = Convert.ToInt32(reader["EquipeID"]);
                            newEvent.EmployeeId = Convert.ToInt32(reader["IDUser"]);
                            newEvent.EventName = reader["Event"].ToString();
                            newEvent.DateStart = Convert.ToDateTime(reader["DateStart"]);
                            newEvent.DateEnd = Convert.ToDateTime(reader["DateEnd"]);
                            newEvent.HourDuration = newEvent.DateEnd.Hour - newEvent.DateStart.Hour;
                            newEvent.MinuteDuration = (newEvent.DateEnd.Minute - newEvent.DateStart.Minute);
                            timetable.Add(newEvent);
               
                        }
                        return timetable;

                    }                 
                }
                catch
                {

                }
                return new List<Event>();
            }
        }
    }
}
