using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class ReadTimes : IReadTimes
    {
        public List<Timestamp> GetEmployeeTimes(int value)
        {
            List<Timestamp> timecards = new List<Timestamp>();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();


            //get the specific Employee based on the ID enetered
            string stm = "select ClockInTime,ClockOutTime, TimeDiff(ClockOutTime, ClockInTime) as TimeSpent, Description,Message from TimeEvent where Employee_ID = @id order by ClockInTime desc;";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", value);

            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();


            //create the TimeStamps
            while(rdr.Read())
            {

                    Timestamp timecard = new Timestamp{
                    ClockInTime = rdr.GetString(0), 
                    ClockOutTime = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                    TimeSpent = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                    Description = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                    Message = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                    Employee_ID = null, 
                    Employee_Name = null,
                    TimeEvent_ID = null
                    };
                
                timecards.Add(timecard);

            }

            return timecards;
        }


        public Timestamp GetEmployeeCurrTime(int value) //get the current work times for a worker. After they sign in the system will see they are on the clock so it will go to another page
        {
            Timestamp timecard = new Timestamp();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();



            string stm = "select * from TimeEvent where Employee_ID = @id and ClockOutTime is null ";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", value);

            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                timecard = new Timestamp{ClockInTime = rdr.GetString(0)};
            }


            return timecard;
         }

        public List<Timestamp> GetDepartmentTimes(string dpt)
        {

            List<Timestamp> timecards = new List<Timestamp>();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();
            string stm ="select ClockInTime,ClockOutTime, TimeDiff(ClockOutTime, ClockInTime) as TimeSpent, Description,Message, e.Employee_ID, Concat(e.F_Name, ' ', e.L_Name) as Employee_Name from timeevent t join employees e on (t.Employee_ID = e.Employee_ID)where e.Employee_ID in(select Employee_ID from Employees where Department_Name = @DPT and Employee_Type = 'worker') order by ClockInTime desc;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@DPT", dpt);

            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            //create the TimeStamps
            while(rdr.Read())
            {

                    Timestamp timecard = new Timestamp{
                    ClockInTime = rdr.GetString(0), 
                    ClockOutTime = rdr.IsDBNull(1) ? null : rdr.GetString(1),
                    TimeSpent = rdr.IsDBNull(2) ? null : rdr.GetString(2),
                    Description = rdr.IsDBNull(3) ? null : rdr.GetString(3),
                    Message = rdr.IsDBNull(4) ? null : rdr.GetString(4),
                    Employee_ID = rdr.GetInt32(5), 
                    Employee_Name = rdr.GetString(6),
                    TimeEvent_ID = null
                    };
                
                timecards.Add(timecard);

            }
            rdr.Read();


            return timecards; // in order from most recent clock in time
        }
    }
}