using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderAdapter
    {
        public static Order ToModelAddRequest(this OrderBuyForYouAddRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderBuyForYouAddRequest, Order>(model);
        }
        public static OrderBuyForYouAddRequest ToModelAddResponse(this Order  model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Order, OrderBuyForYouAddRequest>(model);
        }
        public static OrderViewModel ToModel(this Order model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Order, OrderViewModel>(model);
        }

        public static decimal GetAmountVndEcm(OrderViewModel order)
        {
            var total = Utility.GetPriceForUS(order.Currency, (order.Total ?? 0) + (order.ShippingFee ?? 0) + (order.Surcharge ?? 0)) * (order.ExchangeRate ?? 1);
            var buyFee = (((decimal)((order.BuyFee ?? 0) * (Utility.GetPriceForUS(order.Currency, order.Total ?? 0) ?? 0))) / 100) * (order.ExchangeRate ?? 1);
            var weight = Utility.GetWeightOrder(order.Weight, order.Length, order.Width, order.Hight);
            var shippingUnitGlobal = (order.ShippingUnitGlobal ?? 0) * weight;

            var result = (decimal)(total ?? 0) + buyFee + shippingUnitGlobal + (order.DeliveryFee ?? 0) + (order.StandardFee ?? 0) + (order.BuyServiceFee ?? 0);
            return Math.Round(result);

        }

        public static decimal GetAmountVndTransport(OrderViewModel order, List<OrderPackageProduct> products)
        {
            var result = 0m;
            var buyFee = (((decimal)((order.BuyFee ?? 0) * (Utility.GetPriceForUS(order.Currency, order.Surcharge ?? 0) ?? 0))) / 100) * (order.ExchangeRate ?? 1);
            result = result + (order.Total ?? 0) + buyFee + (order.DeliveryFee ?? 0) + (order.BuyServiceFee ?? 0);
            if (products != null && products.Count > 0)
            {
                var shippingUnitGlobal = products.Sum(x => ((decimal)((x.PriceWeight ?? 0) * (x.Weight ?? 0))) / 1000);
                var standardFee = products.Sum(x => (x.PriceStandard ?? 0) * x.Qty);
                result = result + shippingUnitGlobal + standardFee;
            }
            return Math.Round(result);
        }
    }
    public static class OrderTransportAdapter
    {
        public static Order ToModelOrderTransport(this OrderTransportRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderTransportRequest, Order>(model);
        }


    }
}
