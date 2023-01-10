using apisistec.Dtos.File;
using apisistec.Helpers;
using apisistec.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace apisistec.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private IMediaService _mediaService;

        DefaultResponses response = new();

        public FileController(IMediaService mediaService, IMemoryCache cache)
        {
            _mediaService = mediaService;
            _cache = cache;
        }
        [HttpPost("temp")]
        public IActionResult UploadFileTemp([FromForm] UploadDto upload)
        {
            List<FileUploadedDto> fileUploadedDto = new();
            upload.files.ForEach(file =>
            {
                string tempPath = _mediaService.SaveToTmp(file, file.FileName);
                Guid cacheKey = Guid.NewGuid();
                CancellationTokenSource cts = new();
                _cache.Set($"{cacheKey}_cts", cts);

                MemoryCacheEntryOptions cacheFileOptions = new();
                cacheFileOptions.AbsoluteExpiration = DateTime.Now.AddDays(1);
                cacheFileOptions.AddExpirationToken(new CancellationChangeToken(cts.Token));
                cacheFileOptions.RegisterPostEvictionCallback(callbackExpirateCacheFile, this);
                _cache.Set($"{cacheKey}_file", tempPath, cacheFileOptions);
                fileUploadedDto.Add(new FileUploadedDto
                {
                    cacheKey = cacheKey,
                    size = _mediaService.SizeConverter(file.Length),
                    tempPath = tempPath,
                    name = file.FileName
                });
            });

            return response.SuccessResponse("Ok", fileUploadedDto);
        }
        
        [HttpPost("tmp")]
        public IActionResult UploadFileTmp([FromForm] UploadDto upload)
        {
            IFormFile file = upload.files[0];
            string tempPath = _mediaService.SaveToTmp(file);

            Guid cacheKey = Guid.NewGuid();
            CancellationTokenSource cts = new();
            _cache.Set($"{cacheKey}_cts", cts);

            MemoryCacheEntryOptions cacheFileOptions = new();
            cacheFileOptions.AbsoluteExpiration = DateTime.Now.AddDays(1);
            cacheFileOptions.AddExpirationToken(new CancellationChangeToken(cts.Token));
            cacheFileOptions.RegisterPostEvictionCallback(callbackExpirateCacheFile, this);
            _cache.Set($"{cacheKey}_file", tempPath, cacheFileOptions);
            FileUploadedDto fileUploadedDto = new()
            {
                cacheKey = cacheKey,
                size = _mediaService.SizeConverter(file.Length),
                tempPath = tempPath
            };
            
            return response.SuccessResponse("Ok", fileUploadedDto);
        }

        private static void callbackExpirateCacheFile(object key, object value, EvictionReason reason, object state)
        {
            System.IO.File.Delete(value.ToString());
        }
    }
}
