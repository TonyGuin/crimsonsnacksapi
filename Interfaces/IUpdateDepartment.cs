using api.Models;

namespace api.Interfaces
{
    public interface IUpdateDepartment
    {
         public void UpdateTheDepartment(Department department);
         public void UpdateTheSupervisors(Department department);
    }
}