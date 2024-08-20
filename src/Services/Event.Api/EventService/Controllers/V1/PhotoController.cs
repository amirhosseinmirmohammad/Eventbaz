using Microsoft.AspNetCore.Mvc;
using EventApplication.Services.V1;
using Commons.Models;

namespace EventService.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PhotoController : ControllerBase
    {
        public PhotoController(PhotosService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Upload multiple photos for a specific event property.
        /// </summary>
        /// <param name="EventId">The ID of the event.</param>
        /// <param name="files">List of photo files to upload.</param>
        /// <returns>A ResponseModel containing the URLs of the uploaded photos.</returns>
        [HttpPost("upload/{EventId}")]
        public async Task<ResponseModel<List<string>>> UploadPhotos(int EventId, [FromForm] List<IFormFile> files)
        {
            return await _photoService.AddPhotosToEventAsync(EventId, files);
        }

        /// <summary>
        /// Delete a specific photo from a event property.
        /// </summary>
        /// <param name="EventId">The ID of the event.</param>
        /// <param name="photoId">The ID of the photo to delete.</param>
        /// <returns>A ResponseModel containing the ID of the deleted photo.</returns>
        [HttpDelete("delete/{EventId}/{photoId}")]
        public async Task<ResponseModel<int>> DeletePhoto(int EventId, int photoId)
        {
            return await _photoService.DeletePhotoFromEventAsync(EventId, photoId);
        }

        private readonly PhotosService _photoService;
    }
}
