using System.Threading.Tasks;
using Ichiba.Cdn.Model;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IFileAppService
    {
        Task<FileUploadResponse> Upload(string fileName, byte[] bytes);
        Task<FileUploadResponse> UploadFile(string fileName, byte[] bytes);
    }
}
