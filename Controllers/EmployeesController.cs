using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        // GET: api/Employees
        // [EnableCors("OpenPolicy")] //ADDED
        // [HttpGet("GetDPTEmp/{dpt}", Name = "GetDPTEmp")]           //for managers looking for all employees in a department     make sure only employees not managers or supervisor in SQL
        // public List<Employee> GetDPTEmp(string dpt)
        // {
        //     Console.WriteLine("Get by department");
        //     Employee employee = new Employee();
        //     return employee.read.GetAllDepEmployees(dpt);
        // }

        // GET: api/Employees/5
        [EnableCors("OpenPolicy")] //ADDED             
        [HttpGet("GetEmp/{id}", Name = "GetEmp")]        
        public Employee GetEmp(int id)               
        {
            Console.WriteLine("Made it to Get by ID");
            Employee employee = new Employee();
            return employee.read.GetEmployee(id);
        }

        // GET: api/Employees/5
        [EnableCors("OpenPolicy")] //ADDED              
        [HttpGet("GetEmpLogin/{id}/{password}", Name = "GetEmpLogin")]       
        public Employee GetEmpLogin(int id, string password)               
        {
            Console.WriteLine("Made it to Get by Login");
            Employee employee = new Employee();
            return employee.read.GetEmployeeViaLogin(id, password);
        }

        // GET: api/Employees/5
        [EnableCors("OpenPolicy")] //ADDED           
        [HttpGet("GetCreatedEmp/{Fname}/{Lname}/{phone}/{password}/{dpt}", Name = "GetCreatedEmp")]  
        public Employee GetCreatedEmp(string Fname, string Lname, int phone, string password, string dpt)               
        {
            Console.WriteLine("Made it to Get created emp");
            Employee employee = new Employee();
            return employee.read.GetEmployeeViaNamePhonePasswordDPT(Fname, Lname, phone, password, dpt);
        }















        // POST: api/Employees                    //is what is called when creating a new emp
        [HttpPost("CreateEmp", Name = "CreateEmp")]
        [EnableCors("OpenPolicy")] //ADDED
        public void PostEmp([FromBody] Employee emp)
        {
            Console.WriteLine("Made it to Post emp");
            emp.create.MakeEmployee(emp);
        }



        // PUT: api/Employees/5     is an update for the emp //ex the manager or supervisor changes something
        [EnableCors("OpenPolicy")] //ADDED
        [HttpPut("UpdateEmpPassword", Name = "UpdateEmpPassword")]
        public void PutEmp([FromBody] Employee emp)           //emp id is in the object recieved from the body and the other updated info is as well
        {
            Console.WriteLine("Made it to put emp");
            emp.update.UpdateTheEmployeePassword(emp);
        }

        // PUT: api/Employees/5     is an update for the emp //ex the manager or supervisor changes something
        [EnableCors("OpenPolicy")] //ADDED
        [HttpPut("UpdateEmpHired", Name = "UpdateEmpHired")]
        public void PutEmpHired([FromBody] Employee emp)           //emp id is in the object recieved from the body and the other updated info is as well
        {
            Console.WriteLine("Made it to put emp Hired");
            emp.update.UpdateTheEmployeeHiredStatus(emp.Employee_ID);
        } 





        // DELETE:
        [EnableCors("OpenPolicy")] //ADDED
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
