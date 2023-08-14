using System.Threading.Tasks;
using Ichiba.Cdn.Client.Interface;
using Ichiba.Cdn.Model;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class FileAppService : BaseAppService, IFileAppService
    {
        private readonly IFileStorage fileStorage;

        public FileAppService(ILogger<FileAppService> logger,
            IFileStorage fileStorage)
            : base(logger)
        {
            this.fileStorage = fileStorage;
        }

        public async Task<FileUploadResponse> Upload(string fileName, byte[] bytes)
        {
            const string DEFAULT_CREATED_UID = "default";

            FileUploadResponse response = new FileUploadResponse();

            response = await TryCatchAsync(async () =>
            {
                return await fileStorage.Upload(DEFAULT_CREATED_UID, fileName, bytes);
            }, response);

            return response;
        }

        public async Task<FileUploadResponse> UploadFile(string fileName, byte[] bytes)
        {
            const string DEFAULT_CREATED_UID = "default";

            FileUploadResponse response = new FileUploadResponse();

            response = await TryCatchAsync(async () =>
            {
                return await fileStorage.UploadFile(DEFAULT_CREATED_UID, fileName, bytes);
            }, response);

            return response;
        }
    }
}
