using api.Database;
using api.Interfaces;

namespace api.Models
{
    public class Employee
    {
        public int? Employee_ID { get; set; }
        public string? Department_Name {get; set;}
        public string? Employee_Type {get; set;} //manager or dirrector or worker
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? BirthDate { get; set; }
        public string? F_Name { get; set; }
        public string? L_Name { get; set; }
        public bool? OnTheClock { get; set; } //if they are currently clocked in
        public bool? Hired { get; set; } // if they are an active hired worker

        public ICreateEmployee create {get; set;}
        public IReadEmployee read {get; set;}
        public IUpdateEmployee update{get;set;}

        public Employee()
        {
            create = new CreateEmployee();
            read = new ReadEmployee();
            update = new UpdateEmployee();
        }
    }
}