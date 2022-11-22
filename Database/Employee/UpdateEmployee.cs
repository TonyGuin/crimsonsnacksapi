using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class UpdateEmployee : IUpdateEmployee
    {
        public void UpdateTheEmployeePassword(Employee employee)
        {
            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();


            string stm = @"update Employees set Password = @Password where Employee_ID = @EMPID;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            cmd.Parameters.AddWithValue("@EMPID", employee.Employee_ID);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }
        public void UpdateTheEmployeeWorkingStatus(int? id, bool OnTheClock)
        {
            Database database = new Database();
            using var con = new MySqlConnection(database.cs);

            con.Open();
            string stm = @"update Employees set OnTheClock = @OTC where Employee_ID = @EMPID;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EMPID", id);
            cmd.Parameters.AddWithValue("@OTC", OnTheClock);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
            System.Console.WriteLine("Made it to the end of UpdateTheEmployeeWorkingStatus update");
        }

        public void UpdateTheEmployeeHiredStatus(int? id)
        {
            Database database = new Database();
            using var con = new MySqlConnection(database.cs);

            con.Open();
            string stm = @"update Employees set Hired = false where Employee_ID = @EMPID;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EMPID", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }

        
    }
}