using File_Management_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File_Management_Via_BestTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagementController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public FileManagementController(IStorageService storageService)
        {
            _storageService = storageService;  
        }

        [HttpPost("createFolderAsync")]
        public async Task<IActionResult> CreateFolderAsync( string folderPath)
        {
            try
            {
                await _storageService.CreateFolderAsync(folderPath);
                return Ok("Folder created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating folder: {ex.Message}");
            }   
        }

        [HttpPost("uploadFileAsync")]
        public async Task<IActionResult> UploadFileAsync(string filePath, IFormFile file)
        {
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    await _storageService.UploadFileAsync(filePath, stream);
                }
                return Ok("File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error uploading file: {ex.Message}");
            }
        }

        [HttpGet("downloadFolderAsZipAsync")]
        public async Task<IActionResult> DownloadFolderAsZipAsync(string folderPath)
        {
            try
            {
                var stream = await _storageService.DownloadFolderAsZipAsync(folderPath);
                return File(stream, "application/zip", $"{folderPath}.zip");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error downloading folder as zip: {ex.Message}");
            }
        }

    }
}
