using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetManagementDAL.Data;
using TimesheetManagementDAL.Models;

namespace TimesheetManagementAPIServices.Repositorys
{

    public class TimeSlotRepository : ITimeSlotRepository
    {

        private readonly AppDbContext _appDbContext;


        public TimeSlotRepository(AppDbContext dbContext)
        {
            this._appDbContext = dbContext;
        }

        public async Task Add(TimeSlot timeslot)
        {
            _appDbContext.TimeSlots.Add(timeslot);
            try
            {
                _appDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                TimeSlot timeslot = await _appDbContext.TimeSlots.FindAsync(id);
                _appDbContext.TimeSlots.Remove(timeslot);
                _appDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlots()
        {
            try
            {
                var timeslot = await _appDbContext.TimeSlots.ToListAsync();
                return timeslot;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TimeSlot> GetTimeSlotById(int? id)
        {
            try
            {
                TimeSlot timeslot = await _appDbContext.TimeSlots.FindAsync(id);
                if (timeslot == null)
                {
                    return null;
                }
                return timeslot;
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int id, TimeSlot timeslot)
        {
            {
                try
                {
                    var slot = _appDbContext.TimeSlots.Find(id);
                    if (slot != null)
                    {
                        slot.Start = timeslot.Start;
                        slot.End = timeslot.End;
                        _appDbContext.SaveChanges();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
