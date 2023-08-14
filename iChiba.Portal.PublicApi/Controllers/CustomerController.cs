using System;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using iChiba.Portal.Common;
using iChiba.Portal.PublicApi.AppModel.Response;
using iChibaShopping.Core.AppService.Interface;
using Microsoft.AspNetCore.Hosting;
using Spire.Doc;
using System.Linq;
using System.Drawing;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class CustomerConfig
    {
        public string Add { get; set; }
        public string Update { get; set; }
        public string Detail { get; set; }
        public string GetDetailActivateTransport { get; set; }
        public string CustomerLevel { get; set; }
        public string CustomerLevelPublic { get; set; }
        public string UpdateIdImages { get; set; }
        public string ActivateTransport { get; set; }
        public string AddProfile { get; set; }
        public string UpdateProfile { get; set; }
        public string GetProfileByKey { get; set; }
        public string GetBuyFee { get; set; }
        public string Wallet { get; set; }
        public string GetCashAvailable { get; set; }
        public string GetDebt { get; set; }
        public string UpdateSurvey { get; set; }
    }

    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly CustomerConfig customerConfig;
        private readonly CustomerAddressConfig customerAddressConfig;
        private readonly ICustomerAppService customerAppService;
        private readonly ICustomerAddressAppService customerAddressAppService;
        private readonly ICurrentContext currentContext;
        private readonly IWebHostEnvironment environment;
        private readonly IFileAppService fileAppService;

        public CustomerController(ILogger<CustomerController> logger,
            IOptions<CustomerConfig> customerConfig,
            IOptions<CustomerAddressConfig> customerAddressConfig,
            ICustomerAppService customerAppService,
            ICustomerAddressAppService customerAddressAppService,
            ICurrentContext currentContext,
            IWebHostEnvironment environment,
            IFileAppService fileAppService
            )
            : base(logger)
        {
            this.customerConfig = customerConfig.Value;
            this.customerAddressConfig = customerAddressConfig.Value;
            this.customerAppService = customerAppService;
            this.customerAddressAppService = customerAddressAppService;
            this.currentContext = currentContext;
            this.environment = environment;
            this.fileAppService = fileAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Add(string group = default)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.Add;
            var response = await customerAppService.Add(group, new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.Update;
            var response = await customerAppService.Update(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Customer>))]
        public async Task<IActionResult> GetDetail()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.Detail;
            var response = await customerAppService.GetDetail(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<Customer>))]
        public async Task<IActionResult> GetDetailActivateTransport()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.GetDetailActivateTransport;
            var response = await customerAppService.GetDetailActivateTransport(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Dictionary<string, string>))]
        public async Task<IActionResult> GetCustomerLevel()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.CustomerLevel;
            var response = await customerAppService.GetCustomerLevel(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Dictionary<string, string>))]
        public async Task<IActionResult> GetCustomerLevelPublic()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.CustomerLevelPublic;
            var response = await customerAppService.GetCustomerLevel(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> UpdateIdImages(CustomerVerifyUpdateRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.UpdateIdImages;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAppService.UpdateIdImages(request, baseApi);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> ActivateTransport(ActivateTransportRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.ActivateTransport;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAppService.ActivateTransport(request, baseApi);

            return Ok(response);
        }

        [HttpGet("{key}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<CustomerProfileDetail>))]
        public async Task<IActionResult> GetProfileByKey(string key)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.GetProfileByKey;
            var response = await customerAppService.GetProfileByKey(key, new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<int>))]
        public async Task<IActionResult> GetBuyFee()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.GetBuyFee;
            var response = await customerAppService.GetBuyFee(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<CustomerWallet>))]
        public async Task<IActionResult> GetWallet()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.Wallet;
            var request = new CustomerRequest();
            request.Accesstoken = accessToken;
            request.Url = url;
            var response = await customerAppService.GetWallet(request);
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<long>))]
        public async Task<IActionResult> GetCashAvailable()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.GetCashAvailable;
            var request = new BaseApiRequest();
            request.Accesstoken = accessToken;
            request.Url = url;
            var response = await customerAppService.GetCashAvailable(request);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<CustomerWallet>))]
        public async Task<IActionResult> GetDebt()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.GetDebt;
            var response = await customerAppService.GetDebt(new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            });
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerElectronicContractResponse))]
        public async Task<IActionResult> ElectronicContract()
        {
            var response = new CustomerElectronicContractResponse();
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                //var urlCustomerAddressList = customerAddressConfig.ListAddress;
                var urlCustomerAddressList = customerAddressConfig.GetAddressByCustomer;

                var pathTemplate = Path.Combine(environment.WebRootPath, "ElectronicContract_Template.docx");

                var docxName = $"{currentContext.UserId}_ElectronicContract.docx";
                string docxPath = Path.Combine(environment.WebRootPath, docxName);

                var pdfName = $"{currentContext.UserId}_ElectronicContract.pdf";
                string pdfPath = Path.Combine(environment.WebRootPath, pdfName);

                string imageSignture = string.Empty;
                string docxFileSignture = string.Empty;

                // xử lý luồng add file hợp đồng
                var tasks = new List<Task>();

                var getSigntureContractTask = customerAppService.GetProfileByKey(Constant.CustomerProfileElectronicContract.SIGNTURE_CONTRACT, new BaseApiRequest()
                {
                    Accesstoken = accessToken,
                    Url = customerConfig.GetProfileByKey
                });
                var getElectronicContractTask = customerAppService.GetProfileByKey(Constant.CustomerProfileElectronicContract.ELECTRONIC_CONTRACT, new BaseApiRequest()
                {
                    Accesstoken = accessToken,
                    Url = customerConfig.GetProfileByKey
                });
                tasks.Add(getSigntureContractTask);
                tasks.Add(getElectronicContractTask);
                await Task.WhenAll(tasks);
                var getSigntureContract = await getSigntureContractTask;
                var getElectronicContract = await getElectronicContractTask;
                // check xem đã lưu file chữ ký chưa, nếu chưa lưu tức là chưa ký hợp đồng
                if (getElectronicContract != null && getElectronicContract.Data != null)
                {
                    docxFileSignture = getElectronicContract.Data.Value;
                }

                if (getSigntureContract?.Data == null)
                {
                    //initialize word object
                    var document = new Document();
                    document.LoadFromFile(pathTemplate);

                    var address = string.Empty;

                    var customerAddressTask = customerAddressAppService.ListAddressByCustomer(new BaseApiRequest()
                    {
                        Accesstoken = accessToken,
                        Url = urlCustomerAddressList
                    });

                    var customerDetailTask = customerAppService.GetDetail(new BaseApiRequest
                    {
                        Accesstoken = accessToken,
                        Url = customerConfig.Detail
                    });

                    tasks = new List<Task>();
                    tasks.Add(customerAddressTask);
                    tasks.Add(customerDetailTask);
                    await Task.WhenAll(tasks);

                    var customerAddressResponse = await customerAddressTask;
                    var customerDetailResponse = await customerDetailTask;

                    if (customerAddressResponse != null && customerAddressResponse.Data != null && customerAddressResponse.Data.Count > 0)
                    {
                        var addressDefault = customerAddressResponse.Data.FirstOrDefault(g => g.Active);
                        if (addressDefault == null)
                        {
                            addressDefault = customerAddressResponse.Data.FirstOrDefault();
                        }
                        address = string.Format("{0}, {1}, {2}, {3}", addressDefault.Address,
                                addressDefault.Ward, addressDefault.District, addressDefault.Province);
                    }

                    if (customerDetailResponse != null && customerDetailResponse.Data != null)
                    {
                        var customer = customerDetailResponse.Data;
                        //get strings to replace
                        Dictionary<string, string> dictReplace = GetReplaceDictionary(customer.Fullname, customer.Email, customer.Phone, address, customer.Id);
                        //Replace text
                        foreach (KeyValuePair<string, string> kvp in dictReplace)
                        {
                            document.Replace(kvp.Key, kvp.Value, true, true);
                        }

                        //Save doc file.
                        document.SaveToFile(pdfPath, Spire.Doc.FileFormat.PDF);
                        document.Close();

                        byte[] byteArray = System.IO.File.ReadAllBytes(pdfPath);

                        var responseDocx = await fileAppService.UploadFile(pdfName, byteArray, currentContext.UserId);

                        if (responseDocx != null && responseDocx.Status)
                        {
                            docxFileSignture = responseDocx.Path + "/" + responseDocx.Name;
                            // add file hợp đồng vào đây (file hợp đồng này chưa có chữ ký nhé)
                            await customerAppService.AddProfile(new CustomerProfileRequest()
                            {
                                Key = Constant.CustomerProfileElectronicContract.ELECTRONIC_CONTRACT,
                                Value = docxFileSignture
                            }, new BaseApiRequest
                            {
                                Accesstoken = accessToken,
                                Url = customerConfig.AddProfile
                            });
                        }
                        try
                        {
                            if (System.IO.File.Exists(pdfPath))
                            {
                                System.IO.File.Delete(pdfPath);
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    imageSignture = getSigntureContract?.Data?.Value;
                }

                if (string.IsNullOrWhiteSpace(docxFileSignture))
                {
                    return NoContent();
                }

                response.SetData(new CustomerElectronicContract()
                {
                    ContractFile = docxFileSignture,
                    Signture = imageSignture
                }).Successful();

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerElectronicContractResponse))]
        public async Task<IActionResult> SignContract(byte[] bytesSignture)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var pathTemplate = Path.Combine(environment.WebRootPath, "ElectronicContract_Template.docx");

            var fileNameUpload = currentContext.UserId + ".png";
            var docxName = $"{currentContext.UserId}_ElectronicContract.docx";
            var pdfName = $"{currentContext.UserId}_ElectronicContract.pdf";
            var pathImage = Path.Combine(environment.WebRootPath, fileNameUpload);
            string docxPath = Path.Combine(environment.WebRootPath, docxName);
            string pdfPath = Path.Combine(environment.WebRootPath, pdfName);
            string imageSignture = string.Empty;
            string docxFileSignture = string.Empty;

            var response = new CustomerElectronicContractResponse();

            //lấy thông tin hợp đồng file docx đã lưu ở customer profile
            var getElectronicContract = await customerAppService.GetProfileByKey(Constant.CustomerProfileElectronicContract.ELECTRONIC_CONTRACT, new BaseApiRequest
            {
                Accesstoken = accessToken,
                Url = customerConfig.GetProfileByKey
            });
            if (getElectronicContract != null && getElectronicContract.Data != null)
            {
                // tải file lấy về file stream
                //var document = new Document();
                //var pdfDocument = new PdfDocument();
                //var docxFile = Utility.CreateFullFileUrl(getElectronicContract.Data.Value);

                //using (var client = new WebClient())
                //{
                //    var content = client.DownloadData(docxFile);
                //    using (var stream = new MemoryStream(content))
                //    {
                //        pdfDocument.LoadFromStream(stream);
                //    }
                //}

                //pdfDocument.SaveToFile(docxPath, Spire.Pdf.FileFormat.DOCX);
                //pdfDocument.Close();

                //var bytes = StreamToBytes(streamSignture);
                #region xử lý lưu chữ ký vào file docx
                var document = new Document();
                document.LoadFromFile(pathTemplate);

                //var urlCustomerAddressList = customerAddressConfig.ListAddress;
                var urlCustomerAddressList = customerAddressConfig.GetAddressByCustomer;
                var address = string.Empty;

                var customerAddressTask = customerAddressAppService.ListAddressByCustomer(new BaseApiRequest()
                {
                    Accesstoken = accessToken,
                    Url = urlCustomerAddressList
                });

                var customerDetailTask = customerAppService.GetDetail(new BaseApiRequest
                {
                    Accesstoken = accessToken,
                    Url = customerConfig.Detail
                });

                var tasks = new List<Task>();
                tasks.Add(customerAddressTask);
                tasks.Add(customerDetailTask);
                await Task.WhenAll(tasks);

                var customerAddressResponse = await customerAddressTask;
                var customerDetailResponse = await customerDetailTask;

                if (customerAddressResponse != null && customerAddressResponse.Data != null && customerAddressResponse.Data.Count > 0)
                {
                    var addressDefault = customerAddressResponse.Data.FirstOrDefault(g => g.Active);
                    if (addressDefault == null)
                    {
                        addressDefault = customerAddressResponse.Data.FirstOrDefault();
                    }
                    address = string.Format("{0}, {1}, {2}, {3}", addressDefault.Address,
                            addressDefault.Ward, addressDefault.District, addressDefault.Province);
                }

                if (customerDetailResponse != null && customerDetailResponse.Data != null)
                {
                    var customer = customerDetailResponse.Data;
                    //get strings to replace
                    Dictionary<string, string> dictReplace = GetReplaceDictionary(customer.Fullname, customer.Email, customer.Phone, address, customer.Id);
                    //Replace text
                    foreach (KeyValuePair<string, string> kvp in dictReplace)
                    {
                        document.Replace(kvp.Key, kvp.Value, true, true);
                    }

                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytesSignture))
                    {
                        image = Image.FromStream(ms);
                    }

                    TextSelection selection = document.FindString("«Signature»", true, true);
                    if (selection != null)
                    {
                        DocPicture pic = new DocPicture(document);
                        pic.LoadImage(image);
                        pic.Width = 100;
                        pic.Height = 65;
                        pic.TextWrappingStyle = TextWrappingStyle.InFrontOfText;
                        pic.HorizontalPosition = 50;

                        var range = selection.GetAsOneRange();
                        var index = range.OwnerParagraph.ChildObjects.IndexOf(range);
                        range.OwnerParagraph.ChildObjects.Insert(index, pic);
                        range.OwnerParagraph.ChildObjects.Remove(range);
                        image.Dispose();
                    }

                    //Save doc file.
                    document.SaveToFile(pdfPath, Spire.Doc.FileFormat.PDF);
                    document.Close();

                    #region --Cập nhật lại file hợp đồng đã có chữ ký của khách hàng--

                    byte[] byteArray = System.IO.File.ReadAllBytes(pdfPath);

                    var responseDocx = await fileAppService.UploadFile(pdfName, byteArray, currentContext.UserId);

                    if (responseDocx != null && responseDocx.Status)
                    {
                        docxFileSignture = responseDocx.Path + "/" + responseDocx.Name;

                        await customerAppService.UpdateProfile(new CustomerProfileRequest()
                        {
                            Key = Constant.CustomerProfileElectronicContract.ELECTRONIC_CONTRACT,
                            Value = docxFileSignture
                        }, new BaseApiRequest
                        {
                            Accesstoken = accessToken,
                            Url = customerConfig.UpdateProfile
                        });

                        try
                        {
                            if (System.IO.File.Exists(docxPath))
                            {
                                System.IO.File.Delete(docxPath);
                            }

                            if (System.IO.File.Exists(pdfPath))
                            {
                                System.IO.File.Delete(pdfPath);
                            }
                        }
                        catch
                        {
                        }

                    }
                    #endregion
                }
                #endregion

                #region Tạo file ảnh có chữ ký của khách hàng lưu lên cdn
                //var responseSignture = await fileAppService.Upload(fileNameUpload, bytesSignture, currentContext.UserId);
                var responseSignture = await fileAppService.Upload(fileNameUpload, bytesSignture);
                if (responseSignture != null && responseSignture.Status)
                {
                    imageSignture = responseSignture.Path + "/" + responseSignture.Name;
                    await customerAppService.AddProfile(new CustomerProfileRequest()
                    {
                        Key = Constant.CustomerProfileElectronicContract.SIGNTURE_CONTRACT,
                        Value = imageSignture
                    }, new BaseApiRequest
                    {
                        Accesstoken = accessToken,
                        Url = customerConfig.AddProfile
                    });
                }
                #endregion

                response.SetData(new CustomerElectronicContract()
                {
                    ContractFile = docxFileSignture,
                    Signture = imageSignture
                }).Successful();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSurvey(UpdateSurveyRequest request)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = customerConfig.UpdateSurvey;
            var baseApi = new BaseApiRequest()
            {
                Accesstoken = accessToken,
                Url = url
            };
            var response = await customerAppService.UpdateSurvey(request, baseApi);

            return Ok(response);
        }

        private Dictionary<string, string> GetReplaceDictionary(string fullName, string email, string phoneNumber, string address, int customerId)
        {
            var dt = DateTime.Now;
            Dictionary<string, string> replaceDict = new Dictionary<string, string>();
            replaceDict.Add("«Name»", fullName);
            replaceDict.Add("«Address»", address);
            replaceDict.Add("«PhoneNumber»", phoneNumber);
            replaceDict.Add("«Email»", email);
            replaceDict.Add("«CustomerId»", customerId.ToString());
            replaceDict.Add("«Day»", dt.Day.ToString());
            replaceDict.Add("«Month»", dt.Month.ToString());
            replaceDict.Add("«Year»", dt.Year.ToString());

            return replaceDict;
        }
    }
}
