using Commons.Models;
using EventCore.Interfaces.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using EventCore.Models;

namespace EventApplication.Services.V1
{
    public class PhotosService
    {
        public PhotosService(IEventRepository repository,
                             ILogger<PhotosService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ResponseModel<List<string>>> AddPhotosToEventAsync(int EventId, List<IFormFile> files)
        {
            try
            {
                var Event = await _repository.GetByIdAsync(EventId);
                if (Event != null)
                {
                    var uploadedPhotoUrls = new List<string>();

                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var destinationPath = Path.Combine("wwwroot/images", fileName);
                            using (var stream = new FileStream(destinationPath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var photoUrl = $"/images/{fileName}";
                            uploadedPhotoUrls.Add(photoUrl);

                            //Event.Photos.Add(new EventPhoto
                            //{
                            //    Url = photoUrl,
                            //    EventId = EventId
                            //});
                        }
                        else
                        {
                            _logger.LogWarning("File is empty: {FileName}", file.FileName);
                        }
                    }

                    await _repository.UpdateTimeAsync(Event);
                    _logger.LogInformation("Photos added to Event with ID {EventId}", EventId);

                    return new ResponseModel<List<string>>
                    {
                        StatusCode = (int)ResponseStatus.Success,
                        Data = uploadedPhotoUrls,
                        Message = "Photos uploaded successfully"
                    };
                }

                return new ResponseModel<List<string>>
                {
                    StatusCode = (int)ResponseStatus.NotFound,
                    Data = null,
                    Message = "event not found"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding photos to event");
                return new ResponseModel<List<string>>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = null,
                    Message = "Error adding photos to event",
                    Exception = ex.Message
                };
            }
        }

        public async Task<ResponseModel<int>> DeletePhotoFromEventAsync(int EventId, int photoId)
        {
            try
            {
                var Event = await _repository.GetByIdAsync(EventId);
                //if (Event != null)
                //{
                //    var photo = Event.Photos.FirstOrDefault(p => p.Id == photoId);
                //    if (photo != null)
                //    {
                //        var filePath = Path.Combine("wwwroot/images", Path.GetFileName(photo.PhotoUrl));
                //        if (File.Exists(filePath))
                //        {
                //            File.Delete(filePath);
                //        }

                //        Event.Photos.Remove(photo);
                //        await _repository.UpdateAsync(Event);
                //        _logger.LogInformation("Photo deleted from Event with ID {EventId}", EventId);

                //        return new ResponseModel<int>
                //        {
                //            StatusCode = (int)ResponseStatus.Success,
                //            Data = photoId,
                //            Message = "Photo deleted successfully"
                //        };
                //    }

                //    return new ResponseModel<int>
                //    {
                //        StatusCode = (int)ResponseStatus.NotFound,
                //        Data = 0,
                //        Message = "Photo not found"
                //    };
                //}

                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.NotFound,
                    Data = 0,
                    Message = "event not found"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting photo from event");
                return new ResponseModel<int>
                {
                    StatusCode = (int)ResponseStatus.ServerError,
                    Data = 0,
                    Message = "Error deleting photo from event",
                    Exception = ex.Message
                };
            }
        }

        private readonly IEventRepository _repository;
        private readonly ILogger<PhotosService> _logger;
    }
}
