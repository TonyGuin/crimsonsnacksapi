using api.Database;
using api.Interfaces;

namespace api.Models
{
    public class Department
    {
        public IUpdateDepartment update {get;set;}


        public Department()
        {
            update = new UpdateDepartment();
        }

    }
}