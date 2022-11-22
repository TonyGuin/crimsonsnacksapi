using api.Database;
using api.Interfaces;

namespace api.Models
{
    public class Timestamp
    {
        public string? ClockInTime {get;set;}
        public string? ClockOutTime {get;set;}

        public string? TimeSpent {get;set;}
        public string? Description {get;set;}
        public int? TimeEvent_ID {get;set;}
        public int? Employee_ID { get; set; }
        public string? Message {get;set;}

        public string? Employee_Name {get;set;}

        public IReadTimes read {get; set;}
        public IUpdateTimes update {get; set;}

        public ICreateTimes create {get; set;}

        public Timestamp()
        {
            read = new ReadTimes();
            update = new UpdateTime();
            create = new CreateTime();
        }

    }
}