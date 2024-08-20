using EventCore.Enums;
using EventCore.Interfaces.V1;
using EventCore.Models;
using EventInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EventInfrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventDbContext _context;

        public EventRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Event Event)
        {
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();
            return Event.Id;
        }

        public async Task ArchiveAsync(int id)
        {
            var Event = await _context.Events.FindAsync(id);
            //if (Event != null)
            //{
            //    Event.Status = EventStatus.Archived;
            //    Event.ChangeLogs.Add(new ChangeLog
            //    {
            //        ChangeDate = DateTime.UtcNow,
            //        Description = "Property archived"
            //    });
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events
                //.Include(r => r.Photos)
                .Include(r => r.ChangeLogs)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events
                //.Include(r => r.Photos)
                .Include(r => r.ChangeLogs)
                //.Where(r => r.Status != EventStatus.Archived)
                .OrderByDescending(r => r.UpdatedAt)
                .ToListAsync();
        }

        public async Task UpdateTimeAsync(Event Event)
        {
            _context.Events.Update(Event);
            await _context.SaveChangesAsync();
        }
    }
}
