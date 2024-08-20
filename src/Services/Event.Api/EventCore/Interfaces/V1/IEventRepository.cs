using EventCore.Models;

namespace EventCore.Interfaces.V1
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdAsync(int id);
        Task<int> CreateAsync(Event Event);
        Task UpdateTimeAsync(Event Event);
        Task ArchiveAsync(int id);
    }
}
