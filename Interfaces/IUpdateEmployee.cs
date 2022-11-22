using api.Models;

namespace api.Interfaces
{
    public interface IUpdateEmployee
    {
         
         public void UpdateTheEmployeePassword(Employee employee);

        public void UpdateTheEmployeeWorkingStatus(int? id, bool OnTheClock);

        public void UpdateTheEmployeeHiredStatus(int? id);
    }
}