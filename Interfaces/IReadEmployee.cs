using api.Models;

namespace api.Interfaces
{
    public interface IReadEmployee
    {
         public List<Employee> GetAllDepEmployees(string value);
         public Employee GetEmployee(int value);

         public Employee GetEmployeeViaLogin(int id, string password);
         public Employee GetEmployeeViaNamePhonePasswordDPT(string Fname, string Lname, int phone, string password, string department);
    }
}