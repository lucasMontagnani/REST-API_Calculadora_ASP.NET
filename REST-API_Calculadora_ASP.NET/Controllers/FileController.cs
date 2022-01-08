using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API_Calculadora_ASP.NET.Data.VO;
using REST_API_Calculadora_ASP.NET.Services.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    //[Authorize("Bearer")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("downloadFile/{fileName}")]
        public async Task<IActionResult> GetFileAsync(string fileName)
        {
            byte[] buffer = _fileService.GetFile(fileName);
            if (buffer != null)
            {
                HttpContext.Response.ContentType = $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _fileService.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }

        [HttpPost("uploadMultipleFiles")]
        public async Task<IActionResult> UploadOManyFile([FromForm] List<IFormFile> files)
        {
            List<FileDetailVO> details = await _fileService.SaveFilesToDisk(files);
            return new OkObjectResult(details);
        }
    }
}
