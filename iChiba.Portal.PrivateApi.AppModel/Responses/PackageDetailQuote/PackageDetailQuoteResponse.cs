using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class PackageDetailQuoteListResponse : PagingResponse<IList<PackageDetailQuoteViewModel>>
    {
        public PackageDetailQuoteListResponse()
        {
            Data = new List<PackageDetailQuoteViewModel>();
        }
    }

    public class PackageDetailQuoteResponse : PagingResponse<PackageDetailQuoteViewModel>
    {
        public PackageDetailQuoteResponse()
        {
            Data = new PackageDetailQuoteViewModel();
        }
    }
}
