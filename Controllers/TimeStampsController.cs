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
    public class TimeStampsController : ControllerBase
    {



        // GET: api/TimeStamps/5
        [EnableCors("OpenPolicy")] //ADDED                      //Get all the times for an empoyee
        [HttpGet("GetTimes/{id}", Name = "GetEmpTimes")]
        public List<Timestamp> GetEmpTimes(int id)                  
        {
            Console.WriteLine("Made it to Get by ID for Curr Time");
            Timestamp timecard = new Timestamp();
            return timecard.read.GetEmployeeTimes(id);
        }

        // GET: api/TimeStamps/5
        [EnableCors("OpenPolicy")] //ADDED                      //Get all the times for a dpt
        [HttpGet("GetDptTimes/{Dpt}", Name = "GetDptTimes")]
        public List<Timestamp> GetDptTimes(string Dpt)                  
        {
            Console.WriteLine("Made it to Get by DPT for manager/director");
            Timestamp timecard = new Timestamp();
            return timecard.read.GetDepartmentTimes(Dpt);
        }


        // GET: api/TimeStamps/5
        [EnableCors("OpenPolicy")] //ADDED              //For employee on the clock out page. Need to know clock in time
        [HttpGet("GetInTime/{id}", Name = "GetEmpCurrTime")]
        public Timestamp GetEmpCurrTime(int id)                   
        {
            Console.WriteLine("Made it to Get by ID for Curr Time");
            Timestamp timecard = new Timestamp();
            return timecard.read.GetEmployeeCurrTime(id);
        }








                                                    //is only called when Employee.OnTheClock is false //Only needs Emp id
        // POST: api/TimeStamps                    //is a create new time input for emp. Based off emp id, insert the new row of time into the timestamp table
        [EnableCors("OpenPolicy")] //ADDED
        [HttpPost("CreateInTime", Name = "CreateInTime")]
        
        public void CreateInTime([FromBody] Employee emp)
        {
            Console.WriteLine("Made it to create in Time");
            Timestamp timecard = new Timestamp();
            timecard.create.CreateClockIn(emp.Employee_ID);
            emp.update.UpdateTheEmployeeWorkingStatus(emp.Employee_ID,true); //update the Employee.OnTheClock to true
        }


         // PUT: api/TimeStamps/5                   is an update for a new out time stamp
        [EnableCors("OpenPolicy")] //ADDED
        [HttpPut("UpdateOutTime", Name = "UpdateOutTime")]
        public void UpdateOutTime([FromBody] Timestamp timecard) //Needs employee id, message and description in the body keeping other values null
        {
            Console.WriteLine("Made it to Update out Time");
            Employee employee = new Employee();
            
            timecard.update.UpdateClockOut(timecard);
            employee.update.UpdateTheEmployeeWorkingStatus(timecard.Employee_ID,false);
        }












        // DELETE: api/TimeStamps/5
        [EnableCors("OpenPolicy")] //ADDED
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
