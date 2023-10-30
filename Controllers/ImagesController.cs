using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImageRepository imageRepository;

        public ImagesController(ImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }


        // POST: {apibaseurl}/api/images
        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
        [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
               // File upload
                var blogImage = new BlogImage
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    //DateCreated = DateTime.Now
                };
                blogImage =await imageRepository.Upload(file, blogImage);


                // Convert Domain Model to DTO
                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    Title = blogImage.Title,
                    DateCreated = blogImage.DateCreated,
                    FileExtension = blogImage.FileExtension,
                    FileName = blogImage.FileName,
                    Url = blogImage.Url
                };

                return Ok(blogImage);

            }
            return BadRequest(ModelState);
        }
            private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtenstion = new string[] { ".jpg", ".jpeg", ".png" };

            if(!allowedExtenstion.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "UnSupoorted File Format");
            }

            if(file.Length> 10485760)
            {
                ModelState.AddModelError("file", "File Size can not be more than 10Mb");

            }
        }
     
    }
}