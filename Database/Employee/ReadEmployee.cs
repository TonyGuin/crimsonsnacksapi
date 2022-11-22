using api.Interfaces;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class ReadEmployee : IReadEmployee
    {
        public List<Employee> GetAllDepEmployees(string dep) //for managers and supervisors //just their names NOT TIME
        {
            List<Employee> listEmployees = new List<Employee>();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs); //select * from emp with dept =  and employee type = worker; OR select * from dept ___, then select each from emplyee table
            con.Open();

            string stm = "select * from Employees where Hired = true and Department_Name = @DPTName;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@DPTName", dep);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            DateTime dt = new DateTime();
 

            while(rdr.Read())
            {
                
                Employee employee = new Employee{Employee_ID = int.Parse(rdr.GetString(0)), Department_Name = rdr.GetString(1), Employee_Type = rdr.GetString(2), Password = rdr.GetString(3), Email = rdr.GetString(4), Phone = rdr.GetString(5), F_Name = rdr.GetString(7), L_Name = rdr.GetString(8), OnTheClock = rdr.GetBoolean(9), Hired = rdr.GetBoolean(10)};
                
                dt = Convert.ToDateTime(rdr.GetString(6));
                employee.BirthDate = dt.ToString("yyyy-MM-dd");

                listEmployees.Add(employee);
            

            }

            return listEmployees;
        }

        public Employee GetEmployee(int value)  //JUST EMPLOYEE NOT TIME
        {
            Employee employee = new Employee();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();


            string stm = "select * from Employees where Hired = true and Employee_ID = @EMPID;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EMPID", value);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            DateTime dt = new DateTime();
 
            while(rdr.Read())
            {

                employee = new Employee{Employee_ID = int.Parse(rdr.GetString(0)), Department_Name = rdr.GetString(1), Employee_Type = rdr.GetString(2), Password = rdr.GetString(3), Email = rdr.GetString(4), Phone = rdr.GetString(5), F_Name = rdr.GetString(7), L_Name = rdr.GetString(8), OnTheClock = rdr.GetBoolean(9), Hired = rdr.GetBoolean(10)};
                    
                dt = Convert.ToDateTime(rdr.GetString(6));
                employee.BirthDate = dt.ToString("yyyy-MM-dd");

            }
            return employee;
        }


        public Employee GetEmployeeViaLogin(int id, string password)
        {
            Employee employee = new Employee();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();


            string stm = "select * from Employees where Hired = true and Employee_ID = @EMPID and Password = @Pass;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@EMPID", id);
            cmd.Parameters.AddWithValue("@Pass", password);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            DateTime dt = new DateTime();
 
            while(rdr.Read())
            {

                employee = new Employee{Employee_ID = int.Parse(rdr.GetString(0)), Department_Name = rdr.GetString(1), Employee_Type = rdr.GetString(2), Password = rdr.GetString(3), Email = rdr.GetString(4), Phone = rdr.GetString(5), F_Name = rdr.GetString(7), L_Name = rdr.GetString(8), OnTheClock = rdr.GetBoolean(9), Hired = rdr.GetBoolean(10)};
                    
                dt = Convert.ToDateTime(rdr.GetString(6));
                employee.BirthDate = dt.ToString("yyyy-MM-dd");

            }
            return employee;
        }

        public Employee GetEmployeeViaNamePhonePasswordDPT(string Fname, string Lname, int phone, string password, string department)
        {
            Employee employee = new Employee();

            Database database = new Database();
            using var con = new MySqlConnection(database.cs);
            con.Open();


            string stm = "select * from Employees where Hired = true and f_Name = @FName and l_Name = @LName and phone = @Phone and Password = @Pass and department_name = @DPT;";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@FName", Fname);
            cmd.Parameters.AddWithValue("@LName", Lname);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Pass", password);
            cmd.Parameters.AddWithValue("@DPT", department);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            DateTime dt = new DateTime();
 
            while(rdr.Read())
            {

                employee = new Employee{Employee_ID = int.Parse(rdr.GetString(0)), Department_Name = rdr.GetString(1), Employee_Type = rdr.GetString(2), Password = rdr.GetString(3), Email = rdr.GetString(4), Phone = rdr.GetString(5), F_Name = rdr.GetString(7), L_Name = rdr.GetString(8), OnTheClock = rdr.GetBoolean(9), Hired = rdr.GetBoolean(10)};
                    
                dt = Convert.ToDateTime(rdr.GetString(6));
                employee.BirthDate = dt.ToString("yyyy-MM-dd");

            }
            return employee;
        }
    }
}