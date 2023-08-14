using Core.Common;
using Core.CustomException;
using iChiba.Portal.Common;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter.Helper;
using iChiba.Portal.PrivateApi.AppService.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static iChiba.Portal.Common.EnumDefine;
using ErrorCodeDefine = iChiba.Portal.CustomException.ErrorCodeDefine;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class ExportExcelAppService : IExportExcelAppService
    {
        public void BindingOrderPriceQuotesTransport(ExcelWorksheet worksheet, PackageDetailQuoteViewModel data)
        {
            #region Header

            var rowCurrent = 18;
            const int rowStart = 18;
            var index = 1;

            worksheet.Cells["N17"].Value = $"COD \n ({data.PackageDetails.FirstOrDefault()?.CurrencyCode ?? string.Empty})";

            worksheet.Name = "Phiếu xuất kho";
            worksheet.Cells["A2"].Value = "PHIẾU XUẤT KHO KIÊM GIAO HÀNG";
            worksheet.Cells["A4"].Value = $"Số: {data?.Code ?? string.Empty}";
            if (data.ProcessEmployee != null)
            {
                worksheet.Cells["B5"].Value = "Nhân viên khai thác:";
                worksheet.Cells["C5"].Value = $"{data.ProcessEmployee}";
            }

            //Excel Export Date
            var exportDate = data?.ApprovalDate?.AsDateTime().ToLocalTime() ?? DateTime.UtcNow.ToLocalTime();

            worksheet.Cells["A3"].Value = $"Ngày: {exportDate:dd/MM/yyyy}";

            if (data.Saler != null)
            {
                worksheet.Cells["C6"].Value = data.Saler;
            }

            worksheet.Cells["C7"].Value = data.Customer ?? string.Empty;
            worksheet.Cells["C8"].Value = data.CustomerName ?? string.Empty;
            worksheet.Cells["C10"].Value = data.CustomerPhone ?? string.Empty;
            worksheet.Cells["C11"].Value = data.CustomerFullAddress ?? string.Empty;

            #endregion

            #region Content

            foreach (var order in data.PackageDetails)
            {
                var rowBackOrder = rowCurrent;
                if (!order.Products.Any()) throw new ErrorCodeException(Common.ErrorCodeDefine.NOT_FOUND);
                var listPackage = order.Packages.ToList();

                if (order.Packages.Any(x => x.ParentId != null))
                {
                    order.Packages = order.Packages.Where(x => x.ParentId != null).ToList();
                }

                var packages = order.Packages;

                foreach (var package in packages)
                {
                    var rowBackTracking = rowCurrent;
                    var packageParent = listPackage.FirstOrDefault(x => x.Id.Equals(package.ParentId));
                    var productOfPackage = order.Products.Where(x => x.PackageId.Equals(package.Id)).ToList();
                    if (productOfPackage == null || !productOfPackage.Any()) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                    foreach (var product in productOfPackage)
                    {
                        worksheet.InsertRow(rowCurrent, 1, rowCurrent - 1);
                        worksheet.Row(rowCurrent).Style.Font.Bold = false;

                        ExcelHelper.SetValueRow(worksheet, "A", rowCurrent, index);

                        ExcelHelper.SetValueRow(worksheet, "E", rowCurrent, product.NameCustom);
                        ExcelHelper.SetValueRow(worksheet, "F", rowCurrent, int.Parse(product.ProductUnit));
                        ExcelHelper.SetValueRow(worksheet, "G", rowCurrent, product.Weight); // Trọng lượng thực
                        ExcelHelper.SetValueRow(worksheet, "I", rowCurrent, product.WeightQuote); // Trọng lượng tính giá
                        ExcelHelper.SetValueRow(worksheet, "J", rowCurrent, product.PriceWeight); // Đơn giá VC
                        ExcelHelper.SetValueRowRound(worksheet, $"J{rowCurrent}", $"I{rowCurrent}", $"K{rowCurrent}");
                        ExcelHelper.SetValueRow(worksheet, "L", rowCurrent, product.PriceStandard * int.Parse(product.ProductUnit)); // Todo: Tính theo công thức phụ thu


                        rowCurrent++;
                        index++;
                    }

                    var numberRowMergeTracking = rowCurrent - rowBackTracking - 1;
                    ExcelHelper.SetValueRow(worksheet, "C", rowBackTracking, package?.TrackingCode ?? string.Empty, numberRowMergeTracking);
                    ExcelHelper.SetValueRow(worksheet, "D", rowBackTracking, package?.TrackingNote ?? string.Empty, numberRowMergeTracking);
                    ExcelHelper.SetValueRow(worksheet, "U", rowBackTracking, package?.Note ?? string.Empty, numberRowMergeTracking);
                    if (package?.WeightType != null && package.WeightType.Equals(EnumDefine.WeightPackageType.Dim.GetHashCode()))
                    {
                        var volumeWeight = ((int)package.Length * (int)package.Width * (int)package.Height) / 6000m;
                        ExcelHelper.SetValueRow(worksheet, "H", rowBackTracking, volumeWeight, numberRowMergeTracking);
                    }
                    else
                    {
                        ExcelHelper.SetValueRow(worksheet, "H", rowBackTracking, 0, numberRowMergeTracking);
                    }

                    ExcelHelper.SetValueRow(worksheet, "T", rowBackTracking, package?.ContainerName, numberRowMergeTracking);

                    if (packageParent != null)
                    {
                        ExcelHelper.SetValueRow(worksheet, "U", rowBackTracking, packageParent?.BinLocation != null ? packageParent?.BinLocation.Name : packageParent.LastBinLocation ?? string.Empty, numberRowMergeTracking);
                        ExcelHelper.SetValueRow(worksheet, "V", rowBackTracking, packageParent?.Note ?? string.Empty, numberRowMergeTracking);
                    }
                    else
                    {
                        ExcelHelper.SetValueRow(worksheet, "U", rowBackTracking, package?.BinLocation != null ? package.BinLocation.Name : package?.LastBinLocation ?? string.Empty, numberRowMergeTracking);
                        ExcelHelper.SetValueRow(worksheet, "V", rowBackTracking, package?.Note ?? string.Empty, numberRowMergeTracking);
                    }

                }

                #region Thông tin đơn hàng

                var flightModel = packages.First().Flight;

                var warehouseCreate = string.Empty;
                var flightCode = string.Empty;
                var dateArrival = string.Empty;
                if (flightModel != null)
                {
                    warehouseCreate = flightModel.CreatedWarehouseCode.Replace("W", "");
                    flightCode = flightModel.Code.Substring(flightModel.Code.Length - 4, 4);
                    dateArrival = flightModel.DateArrival != null ? flightModel.DateArrival.AsDateTime().ToString("dd/MM/yyyy") : string.Empty;
                }

                var numberRowMergeOrder = rowCurrent - rowBackOrder - 1;
                ExcelHelper.SetValueRow(worksheet, "B", rowBackOrder,
                    !string.IsNullOrEmpty(dateArrival)
                    ? $"{order.OrderCode}\n ({warehouseCreate} - {flightCode})\n {dateArrival}"
                    : $"{order.OrderCode}\n ({warehouseCreate} - {flightCode})",
                    numberRowMergeOrder
                );


                ExcelHelper.SetValueRow(worksheet, "M", rowBackOrder, order.TotalServiceFee ?? 0, numberRowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "N", rowBackOrder, order.SurchargeDisplay, numberRowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "O", rowBackOrder, order.CurrencyRate ?? 0, numberRowMergeOrder);
                ExcelHelper.SetValueTotalPriceCod(worksheet, order.CurrencyCode, "N", "O", "P", rowBackOrder, numberRowMergeOrder);
                ExcelHelper.SetValueRowRoundWithNumber(worksheet, "P", (order.BuyFee ?? 0) * 0.01M, "Q", rowBackOrder, numberRowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "R", rowBackOrder, order.DeliveryFee ?? 0, numberRowMergeOrder);
                ExcelHelper.SetValueTotalAmount(worksheet, rowBackOrder, rowCurrent - 1);

                #endregion
            }

            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "F");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "G");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "H");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "I");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "K");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "L");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "M");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "N");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "P");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "Q");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "R");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "S");

            // Paid
            var paid = data.PackageDetails.Sum(x => x.Paid ?? 0);
            ExcelHelper.SetValueRow(worksheet, "R", rowCurrent + 2, paid);

            // COD
            ExcelHelper.SetValueRowSubRoundMoney(worksheet, $"S{rowCurrent}", $"R{rowCurrent + 2}", $"R{rowCurrent + 3}");

            #region Thông tin giao hàng
            // Hình thức thanh toán
            var totalAmount = data.PackageDetails.Sum(x => x.TotalAmount ?? 0M);

            // COD
            //var cod = RoundingMoneyVn((totalAmount - paid));
            //ExcelHelper.SetValueRow(worksheet, "Q", rowCurrent + 3, cod);

            ExcelHelper.SetValueRow(worksheet, "R", rowCurrent + 4, (data.Cod ?? false) ? "TM" : "CK");

            //// Hình thức giao hàng
            var valueRowTypeShipping = $"{((ShippingUnitType)(data.ShippingUnitType ?? 1)).GetDisplayName()} \n";
            if (!string.IsNullOrEmpty(data.PoNumber))
            {
                valueRowTypeShipping += $"MVĐ: {data.PoNumber} \n";
            }
            if (!string.IsNullOrEmpty(data.Note))
            {
                valueRowTypeShipping += $"Ghi chú: {data.Note}";
            }
            ExcelHelper.SetValueRow(worksheet, "R", rowCurrent + 5, valueRowTypeShipping);

            #endregion

            #endregion
        }

        public void BindingOrderPriceQuotesEcm(ExcelWorksheet worksheet, PackageDetailQuoteViewModel data)
        {
            #region Header

            var rowCurrent = 18;
            const int rowStart = 18;
            var index = 1;

            worksheet.Cells["A2"].Value = $"PHIẾU XUẤT KHO KIÊM GIAO HÀNG";
            worksheet.Cells["A4"].Value = $"Số: {data.Code ?? string.Empty}";
            if (data.ProcessEmployee != null)
            {
                worksheet.Cells["B5"].Value = $"Nhân viên khai thác:";
                worksheet.Cells["C5"].Value = data.ProcessEmployee;
            }
            worksheet.Name = "Phiếu xuất kho";

            var exportDate = data?.ApprovalDate?.AsDateTime().ToLocalTime() ?? DateTime.UtcNow.ToLocalTime();

            worksheet.Cells["A3"].Value = $"Ngày: {exportDate:dd/MM/yyyy}";

            if (data.Saler != null)
            {
                worksheet.Cells["C6"].Value = data.Saler;
            }

            worksheet.Cells["C7"].Value = data.Customer ?? string.Empty;
            worksheet.Cells["C8"].Value = data.CustomerName ?? string.Empty;
            worksheet.Cells["C10"].Value = data.CustomerPhone ?? string.Empty;
            worksheet.Cells["C11"].Value = data.CustomerFullAddress ?? string.Empty;

            worksheet.Cells["K17"].Value = $"Giá web \n ({data.PackageDetails.FirstOrDefault()?.CurrencyCode ?? string.Empty})";
            worksheet.Cells["L17"].Value = $"Phí ship nội địa\n ({data.PackageDetails.FirstOrDefault()?.CurrencyCode ?? string.Empty})";
            worksheet.Cells["M17"].Value = $"Phụ phí \n ({data.PackageDetails.FirstOrDefault()?.CurrencyCode ?? string.Empty})";
            worksheet.Cells["N17"].Value = $"Thành tiền \n ({data.PackageDetails.FirstOrDefault()?.CurrencyCode ?? string.Empty})";

            #endregion

            #region Content

            foreach (var order in data.PackageDetails)
            {
                var rowBackOrder = rowCurrent;

                #region Thông tin sản phẩm

                foreach (var product in order.Products)
                {
                    worksheet.InsertRow(rowCurrent, 1, rowCurrent - 1);
                    worksheet.Row(rowCurrent).Style.Font.Bold = false;

                    ExcelHelper.SetValueRow(worksheet, "A", rowCurrent, index);
                    try
                    {
                        ExcelHelper.AutoHyperlink(worksheet, "B", rowCurrent, product.Url ?? string.Empty);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    ExcelHelper.SetValueRow(worksheet, "C", rowCurrent, product.NameCustom ?? string.Empty);
                    ExcelHelper.SetValueRow(worksheet, "G", rowCurrent, product.QtyPerUnit ?? 0);
                    ExcelHelper.SetValueTotalPrice(worksheet, rowCurrent, product.Price ?? 0, product.Tax ?? 0M, order.CurrencyCode);
                    ExcelHelper.SetValueRow(worksheet, "S", rowBackOrder, (product.PriceStandard ?? 0) * int.Parse(product.ProductUnit ?? "0"));
                    rowCurrent++;
                    index++;
                }

                #endregion

                #region Thông tin mawb
                var flightModel = order.Packages.First().Flight;

                var warehouseCreate = string.Empty;
                var flightCode = string.Empty;
                var dateArrival = string.Empty;
                if (flightModel != null)
                {
                    warehouseCreate = flightModel.CreatedWarehouseCode.Replace("W", "");
                    flightCode = flightModel.Code.Substring(flightModel.Code.Length - 4, 4);
                    dateArrival = flightModel.DateArrival != null ? flightModel.DateArrival.AsDateTime().ToString("dd/MM/yyyy") : string.Empty;
                }

                #endregion

                var rowMergeOrder = rowCurrent - rowBackOrder - 1;

                var packages = order.Packages;
                foreach (var package in packages)
                {
                    ExcelHelper.SetValueRow(worksheet, "W", rowBackOrder, package.Note, rowMergeOrder);
                }

                ExcelHelper.SetValueRow(worksheet, "D", rowBackOrder,
                    !string.IsNullOrEmpty(dateArrival)
                    ? $"{order.OrderCode}\n ({warehouseCreate} - {flightCode})\n {dateArrival}"
                    : $"{order.OrderCode}\n ({warehouseCreate} - {flightCode})",
                    rowMergeOrder
                );

                ExcelHelper.SetValueRow(worksheet,
                    "E",
                    rowBackOrder,
                    string.Join(",", order.Packages.Select(x => x.TrackingCode)),
                    rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet,
                    "F",
                    rowBackOrder,
                    string.Join(",", order.Packages.Select(x => x.TrackingNote)),
                    rowMergeOrder);

                ExcelHelper.SetValueRow(worksheet, "H", rowBackOrder, order.Weight ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "I", rowBackOrder, order.WeightDim ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "J", rowBackOrder, order.WeightQuote ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "L", rowBackOrder, order.ShippingFee ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "M", rowBackOrder, order.Surcharge ?? 0, rowMergeOrder);
                ExcelHelper.SetValueTotalPriceEcm(worksheet, rowBackOrder, order.Total ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "O", rowBackOrder, order.CurrencyRate ?? 0, rowMergeOrder);
                ExcelHelper.SetValueTotalFeeEcm(
                    worksheet,
                    order.CurrencyCode,
                    $"N{rowBackOrder}",
                    $"O{rowBackOrder}",
                    $"P",
                    rowBackOrder,
                    rowMergeOrder);

                ExcelHelper.SetValueRow(worksheet, "Q", rowBackOrder, (order.BuyFee ?? 0M) * 0.01M, rowMergeOrder);
                ExcelHelper.SetValueRowRoundAndMergeRowResult(
                    worksheet,
                    $"P{rowBackOrder}",
                    $"Q{rowBackOrder}",
                    $"R",
                    rowBackOrder,
                    rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "T", rowBackOrder, order.ShippingUnitGlobal ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRowRoundAndMergeRowResult(
                    worksheet,
                    $"T{rowBackOrder}",
                    $"J{rowBackOrder}",
                    "U",
                    rowBackOrder,
                    rowMergeOrder);

                ExcelHelper.SetValueRow(worksheet, "V", rowBackOrder, order.ShippingFeeDomestic ?? 0, rowMergeOrder);
                ExcelHelper.SetValueRow(worksheet, "W", rowBackOrder, order.Paid ?? 0, rowMergeOrder);
                ExcelHelper.SetValueTotalPayment(
                    worksheet,
                    rowBackOrder,
                    new List<string> { "P", "R", "U", "V", "S" },
                    "X",
                    rowBackOrder,
                    rowMergeOrder,
                    order.BuyServiceFee,
                    order.CurrencyRate);
                ExcelHelper.SetValueRow(
                    worksheet,
                    "Y",
                    rowBackOrder,
                    string.Join(",", order.Packages.Select(x => x.ContainerName).ToList()),
                    rowMergeOrder);
                //canhnd
                ExcelHelper.SetValueRow(
                   worksheet,
                   "Z",
                   rowBackOrder,
                   string.Join(",", order.Packages.Select(x => x.BinLocation != null ? x.BinLocation.Name : x.LastBinLocation ?? string.Empty)),
                   rowMergeOrder);
                ExcelHelper.SetValueRow(
                    worksheet,
                    "AA",
                    rowBackOrder,
                    string.Join("\n", order.Packages.Select(x => x.Note ?? string.Empty)),
                    rowMergeOrder);
            }

            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "G");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "H");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "I");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "J");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "K");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "L");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "M");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "N");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "P");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "R");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "S");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "U");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "V");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "W");
            ExcelHelper.SetValueRowSum(worksheet, rowStart, rowCurrent, "X");

            // Paid
            var paid = data.PackageDetails.Sum(x => x.Paid ?? 0);
            ExcelHelper.SetValueRow(worksheet, "V", rowCurrent + 2, paid);

            // COD
            ExcelHelper.SetValueRowSubRoundMoney(worksheet, $"X{rowCurrent}", $"V{rowCurrent + 2}", $"V{rowCurrent + 3}");

            #region Thông tin giao hàng

            // Hình thức thanh toán
            ExcelHelper.SetValueRow(worksheet, "V", rowCurrent + 4, (data.Cod ?? false) ? "TM" : "CK");

            // Phương thức giao hàng
            var valueRowShippingType = $"{((ShippingUnitType)data.ShippingUnitType).GetDisplayName()} \n";

            if (!string.IsNullOrEmpty(data.PoNumber))
            {
                valueRowShippingType += $"MVĐ: {data.PoNumber} \n";
            }
            if (!string.IsNullOrEmpty(data.Note))
            {
                valueRowShippingType += $"Ghi chú: {data.Note}";
            }
            ExcelHelper.SetValueRow(worksheet, "V", rowCurrent + 5, valueRowShippingType);

            var route = data.PackageDetails?.FirstOrDefault()?.OrderCode.Substring(0, 2);
            if (route == "JP")
            {
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 7, $"Tài khoản giao dịch tuyến Nhật Bản - Việt Nam");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 8, $"1");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 8, $"Đỗ Mạnh Hải - STK 0011004099865 - Ngân hàng TMCP Ngoại Thương VN – Vietcombank, chi nhánh Tây Hồ");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 9, $"2");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 9, $"Đỗ Mạnh Hải - STK 22210004099399 - Ngân hàng Đầu Tư và Phát Triển Việt Nam – BIDV, chi nhánh Thanh Xuân");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 10, $"3");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 10, $"Đỗ Mạnh Hải - STK 104872082549 - Ngân hàng TMCP Công Thương VN – Vietinbank, chi nhánh Quang Minh");
            }
            else
            {
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 7, $"Tài khoản giao dịch");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 8, $"1");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 8, $"Tạ Thị Hồng Hạnh - STK 19034751115019 - Ngân hàng TMCP Kỹ Thương VN - Techcombank - CN KEANGGNAM");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 9, $"2");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 9, $"Tạ Thị Hồng Hạnh - STK 1017749789 - Ngân hàng TMCP Ngoại Thương VN - Vietcombank - CN Thành Công - PGD Mỹ Đình");
                ExcelHelper.SetValueRow(worksheet, "A", rowCurrent + 10, $"3");
                ExcelHelper.SetValueRow(worksheet, "B", rowCurrent + 10, $"Tạ Thị Hồng Hạnh - STK 12910000345319 - Ngân hàng Đầu Tư và Phát Triển Việt Nam - BIDV - CN Hoàng Mai Hà Nội");
            }
            #endregion

            #endregion
        }
    }
}
