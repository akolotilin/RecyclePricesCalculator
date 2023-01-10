using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using VmsInform.Common.Services;
using static System.Net.Mime.MediaTypeNames;

namespace VmsInformWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService)
        {
            _pictureService = pictureService ?? throw new ArgumentNullException(nameof(pictureService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPicture(long id)
        {
            var data = await _pictureService.GetPicture(id);
            return File(data, Image.Jpeg);
        }

        [HttpPost("upload")]
        public async Task<ActionResult> Upload(IFormFile file)
        {
            using (var buffer = new MemoryStream())
            {
                await file.CopyToAsync(buffer);
                await buffer.FlushAsync();
                var pictureId = await _pictureService.AddPicture(buffer.GetBuffer());
                return Ok(pictureId);
            }
        }

        [HttpGet("{id}/thumbnail")]
        public async Task<ActionResult> GetThumbnail(long id, [FromQuery] int size = 128)
        {
            var data = await _pictureService.GetThumbnail(id, size);
            return File(data, Image.Jpeg);
        }
    }
}