using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace UploadFiles.Data
{
    [Route("api/[controller]")]
    public class SampleDataController : ControllerBase
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnv;
       
        public SampleDataController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        [HttpPost("[action]")]
        public void Save(IList<IFormFile> chunkFile, IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in chunkFile)
                {
                    if (UploadFiles != null)
                    {
                        var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filename = hostingEnv.WebRootPath + $@"\{filename}";
                        if (!System.IO.File.Exists(filename))
                        {
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else
                        {
                            Response.Clear();
                            Response.StatusCode = 204;
                            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File already exists.";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 204;
                // throw exception"No Content";
            }

        }
        [HttpPost("[action]")]
        public void Remove(string UploadFiles)
        {
            try
            {
                var fileName = UploadFiles;
                var filePath = Path.Combine(hostingEnv.WebRootPath);
                var fileSavePath = filePath + "\\" + fileName;
                if (System.IO.File.Exists(fileSavePath))
                {
                    System.IO.File.Delete(fileSavePath);
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                //throw exception "File removed successfully";
            }
        }
    }
}
