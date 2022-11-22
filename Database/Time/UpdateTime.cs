using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class UpdateTime : IUpdateTimes
    {
        public void UpdateClockOut(Timestamp timecard)
        {
            
            Database database = new Database();
            DateTime now = DateTime.Now;

            using var con = new MySqlConnection(database.cs);
            con.Open();

            
            string stm = @"update TimeEvent set ClockOutTime = @Now, Description = @description, Message = @messgae where Employee_ID = @EMPId and ClockOutTime is null;";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@Now", now);
            cmd.Parameters.AddWithValue("@description", timecard.Description);
            cmd.Parameters.AddWithValue("@messgae", timecard.Message);
            cmd.Parameters.AddWithValue("@EMPId", timecard.Employee_ID);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}