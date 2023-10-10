using TimesheetManagementDAL.Models;

namespace TimesheetManagementAPIServices.Repositorys
{
    public interface ITimeSlotRepository
    {
        Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
        Task<TimeSlot> GetTimeSlotById(int? id);
        Task Add(TimeSlot timeSlot);
        Task Update(int id, TimeSlot timeSlot);
        Task Delete(int id);
    }
}
