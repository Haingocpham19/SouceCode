namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IUploadFileAppService
    {
        string UploadFile(byte[] file, string fileName, string nameFolder);
    }
}
