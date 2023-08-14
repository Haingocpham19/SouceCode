using Core.AppModel.Response;
using Ichiba.WH.Api.Driver.Model.Warehouse;
using System.Collections.Generic;

namespace Ichiba.WH.Api.Driver.Response
{
    public class WarehouseListResponse : PagingResponse<IList<WarehouseList>>
    {
        public WarehouseListResponse()
        {
            Data = new List<WarehouseList>();
        }
    }

    public class WarehouseResponse : BaseEntityResponse<WarehouseViewModel>
    {
        public WarehouseResponse()
        {
            Data = new WarehouseViewModel();
        }
    }
}
