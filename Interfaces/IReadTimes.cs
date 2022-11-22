using api.Models;

namespace api.Interfaces
{
    public interface IReadTimes
    {
         public Timestamp GetEmployeeCurrTime(int value);
         public List<Timestamp> GetEmployeeTimes(int value);

         public List<Timestamp> GetDepartmentTimes(string dpt);
    }
}