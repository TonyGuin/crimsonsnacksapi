using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class CreateEmployee : ICreateEmployee
    {
        public void MakeEmployee(Employee employee)
        {
            Database database = new Database();

            using var con = new MySqlConnection(database.cs);
            con.Open();
            
            //create a new Employee
            string stm = @"insert into Employees(Department_Name,Employee_Type,Password,Email,Phone,BirthDate,F_Name,L_Name,OnTheClock,Hired) values(@DPTName, @EMPType, @Password, @Email, @Phone,@BDay, @FName, @LName, @OnTheClock, @Hired);";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@DPTName", employee.Department_Name);
            cmd.Parameters.AddWithValue("@EMPType", employee.Employee_Type);
            cmd.Parameters.AddWithValue("@Password", employee.Password);
            cmd.Parameters.AddWithValue("@Email", employee.Email);
            cmd.Parameters.AddWithValue("@Phone", employee.Phone);
            cmd.Parameters.AddWithValue("@BDay", employee.BirthDate);
            cmd.Parameters.AddWithValue("@FName", employee.F_Name);
            cmd.Parameters.AddWithValue("@LName", employee.L_Name);
            cmd.Parameters.AddWithValue("@OnTheClock", employee.OnTheClock);
            cmd.Parameters.AddWithValue("@Hired", employee.Hired);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }

    }
}