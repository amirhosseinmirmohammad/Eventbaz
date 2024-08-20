using Commons.Models;
using EventApplication.Services.V1;
using EventApplication.ViewModels;
using EventCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="EventService">The service for managing event operations.</param>
        public EventsController(EventsService EventService)
        {
            _eventService = EventService;
        }

        /// <summary>
        /// Adds a new event property.
        /// </summary>
        /// <param name="EventViewModel">The view model containing the details of the event property.</param>
        /// <returns>A <see cref="ResponseModel{T}"/> containing the ID of the newly added event property.</returns>
        [HttpPost("add")]
        public async Task<ResponseModel<int>> Create([FromBody] EventViewModel EventViewModel)
        {
            return await _eventService.CreateAsync(EventViewModel);
        }

        /// <summary>
        /// Archives an existing event property by its ID.
        /// </summary>
        /// <param name="id">The ID of the event property to archive.</param>
        /// <returns>A <see cref="ResponseModel{T}"/> indicating the status of the operation.</returns>
        [HttpPut("archive/{id}")]
        public async Task<ResponseModel<int>> Archive(int id)
        {
            return await _eventService.ArchiveAsync(id);
        }

        /// <summary>
        /// Updates the timestamp of an existing event property.
        /// </summary>
        /// <param name="id">The ID of the event property to update.</param>
        /// <returns>A <see cref="ResponseModel{T}"/> containing the ID of the updated event property.</returns>
        [HttpPut("update-time/{id}")]
        public async Task<ResponseModel<int>> UpdateTime(int id)
        {
            return await _eventService.UpdateTimeAsync(id);
        }

        /// <summary>
        /// Retrieves a list of all event properties.
        /// </summary>
        /// <returns>A <see cref="ResponseModel{T}"/> containing a list of all event properties.</returns>
        [HttpGet("list")]
        public async Task<ResponseModel<IEnumerable<Event>>> GetAll()
        {
            return await _eventService.GetAllAsync();
        }

        private readonly EventsService _eventService;
    }
}
