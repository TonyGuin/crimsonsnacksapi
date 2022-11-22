using api.Models;

namespace api.Interfaces
{
    public interface IUpdateTimes
    {
         public void UpdateClockOut(Timestamp timecard);
    }
}