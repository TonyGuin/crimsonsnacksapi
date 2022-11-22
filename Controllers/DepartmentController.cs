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
    public class DepartmentController : ControllerBase
    {

        // // GET: api/CrimsonSnacks
        // [EnableCors("OpenPolicy")] //ADDED
        // [HttpGet("GetDPT/{dpt}", Name = "GetDPTEmp")]           //for managers looking for all employees in a department     make sure only employees not managers or supervisor in SQL
        // public List<Employee> GetDPTEmp(string dpt)
        // {
        //     Console.WriteLine("Get by department");
        //     Employee employee = new Employee();
        //     return employee.read.GetAllDepEmployees(dpt);
        // }




        // // POST: api/CrimsonSnacks                    //is what is called when creating a new emp
        // [HttpPost("CreateEmp", Name = "PostEmp")]
        // [EnableCors("OpenPolicy")] //ADDED
        // public void PostEmp([FromBody] string emp)
        // {
        // }





        // // PUT: api/CrimsonSnacks/5                         is an update for the emp //ex the manager or supervisor
        // [EnableCors("OpenPolicy")] //ADDED
        // [HttpPut("UpdateEmp", Name = "PutEmp")]
        // public void PutEmp([FromBody] string emp)           //emp id is in the object recieved from the body and the other updated info is as well
        // {
        // }







        // // DELETE: api/CrimsonSnacks/5
        // [EnableCors("OpenPolicy")] //ADDED
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
