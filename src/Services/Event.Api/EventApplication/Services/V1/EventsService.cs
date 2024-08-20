using Commons.Models;
using EventApplication.ViewModels;
using EventCore.Enums;
using EventCore.Interfaces.V1;
using EventCore.Models;
using Microsoft.Extensions.Logging;

namespace EventApplication.Services.V1
{
    public class EventsService
    {
        public EventsService(IEventRepository repository,
                             ILogger<EventsService> logger)
        {
            _repository = repository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResponseModel<int>> CreateAsync(EventViewModel viewModel)
        {
            try
            {
                var Event = new Event
                {
                    Title = viewModel.Title,
                    Status = viewModel.Status,
                    Price = viewModel.Price,
                    //Floor = viewModel.Floor,
                    UserId = "UserId",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var id = await _repository.CreateAsync(Event);
                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Data = id,
                    Message = "event added successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding event");
                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = 0,
                    Message = "Error adding event",
                    Exception = ex.Message
                };
            }
        }

        public async Task<ResponseModel<int>> ArchiveAsync(int id)
        {
            try
            {
                var Event = await _repository.GetByIdAsync(id);
                if (Event != null)
                {
                    Event.Status = EventStatus.Archived;
                    Event.UpdatedAt = DateTime.UtcNow;

                    //Event.ChangeLogs.Add(new ChangeLog
                    //{
                    //    ChangeDate = DateTime.UtcNow,
                    //    Description = "Property archived"
                    //});

                    await _repository.UpdateTimeAsync(Event);
                    _logger.LogInformation("Archived Event with ID {EventId}", id);

                    return new ResponseModel<int>
                    {
                        StatusCode = (int)ResponseStatus.Success,
                        Data = id,
                        Message = "event archived successfully"
                    };
                }

                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.NotFound,
                    Data = 0,
                    Message = "event not found"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error archiving event");
                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = 0,
                    Message = "Error archiving event",
                    Exception = ex.Message
                };
            }
        }

        public async Task<ResponseModel<int>> UpdateTimeAsync(int id)
        {
            try
            {
                var Event = await _repository.GetByIdAsync(id);
                if (Event != null)
                {
                    Event.UpdatedAt = DateTime.UtcNow;

                    //Event.ChangeLogs.Add(new ChangeLog
                    //{
                    //    ChangeDate = DateTime.UtcNow,
                    //    Description = "Updated property time"
                    //});

                    await _repository.UpdateTimeAsync(Event);
                    _logger.LogInformation("Updated time for Event with ID {EventId}", id);

                    return new ResponseModel<int>
                    {
                        StatusCode = (int)ResponseStatus.Success,
                        Data = id,
                        Message = "event time updated successfully"
                    };
                }

                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.NotFound,
                    Data = 0,
                    Message = "event not found"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating event time");
                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = 0,
                    Message = "Error updating event time",
                    Exception = ex.Message
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<Event>>> GetAllAsync()
        {
            try
            {
                var allEvents = await _repository.GetAllAsync();
                return new ResponseModel<IEnumerable<Event>>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Data = allEvents.OrderByDescending(r => r.UpdatedAt),
                    Message = "event list retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving event list");
                return new ResponseModel<IEnumerable<Event>>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = null,
                    Message = "Error retrieving event list",
                    Exception = ex.Message
                };
            }
        }

        private readonly IEventRepository _repository;
        private readonly ILogger<EventsService> _logger;
    }
}
