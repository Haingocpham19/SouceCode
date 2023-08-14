using System.IO;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.AspNetCore.Hosting;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class UploadFileAppService : IUploadFileAppService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadFileAppService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string UploadFile(byte[] file, string fileName, string nameFolder)
        {
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, nameFolder);
                string fullPath = string.Empty;
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    fullPath = Path.Combine(newPath, fileName);
                    File.WriteAllBytes(fullPath, file);
                }

                return fullPath;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
