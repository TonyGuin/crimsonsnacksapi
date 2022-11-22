using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;


namespace api.Database
{
    public class CreateTime : ICreateTimes
    {
        public void CreateClockIn(int? id)
        {

            Database database = new Database();
            DateTime now = DateTime.Now;

            using var con = new MySqlConnection(database.cs);
            con.Open();
            
            string stm = @"insert into TimeEvent(ClockInTime,Employee_ID) values(@Now,@EMPId);";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EMPId", id);
            cmd.Parameters.AddWithValue("@Now", now);
            cmd.Prepare();
            cmd.ExecuteNonQuery();


        }
    }
}