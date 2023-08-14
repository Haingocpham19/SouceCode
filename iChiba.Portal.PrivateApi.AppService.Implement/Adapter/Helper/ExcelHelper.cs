using iChiba.Portal.Common;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter.Helper
{
    public class ExcelHelper
    {
        public static void SetValueRowSum(ExcelWorksheet worksheet, int rowStart, int rowEnd, string col)
        {
            var sumOp = $"SUM({col}{rowStart}:{col}{rowEnd - 1})";

            worksheet.Cells[$"{col}{rowEnd}"].Formula = sumOp;
        }

        public static void SetValueRowInvertSum(ExcelWorksheet worksheet, int rowStart, int rowEnd, int rowResult, string colResult)
        {
            var sumOp = $"SUM({colResult}{rowStart}:{colResult}{rowEnd - 1})";

            worksheet.Cells[$"{colResult}{rowResult}"].Formula = sumOp;
        }

        public static void SetValueRowSub(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult)
        {
            var subOp = $"=({colOne}-{colTwo})";

            worksheet.Cells[$"{colResult}"].Formula = subOp;
        }

        public static void SetValueRowSubRoundMoney(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult)
        {
            var subOp = $"=ROUNDUP({colOne}-{colTwo}, -3)";

            worksheet.Cells[$"{colResult}"].Formula = subOp;
        }

        public static object SetValueRowSumAndGetValue(ExcelWorksheet worksheet, int rowStart, int rowEnd, string col)
        {
            var sumOp = $"SUM({col}{rowStart}:{col}{rowEnd - 1})";

            worksheet.Cells[$"{col}{rowEnd}"].Formula = sumOp;
            return worksheet.Cells[$"{col}{rowEnd}"].Value;
        }
        public static object SetValueRowSumAndGetValue(ExcelWorksheet worksheet, int rowStart, int rowEnd, string col, int displayValueSum)
        {
            var sumOp = $"SUM({col}{rowStart}:{col}{rowEnd - 1})";

            worksheet.Cells[$"{col}{displayValueSum}"].Formula = sumOp;
            return worksheet.Cells[$"{col}{displayValueSum}"].Value;
        }

        public static void SetValueColSumRange(ExcelWorksheet worksheet, int row, string colStart, string colEnd, string colResult)
        {
            var sumOp = $"SUM({colStart}{row}:{colEnd}{row})";

            worksheet.Cells[$"{colResult}{row}"].Formula = sumOp;
        }

        public static void SetValueColSum(ExcelWorksheet worksheet, int row, List<string> cols, string colResult)
        {
            var colSum = string.Empty;
            foreach (var col in cols)
            {
                if (!string.IsNullOrEmpty(colSum))
                {
                    colSum += $"{col}{row},";
                }
                else
                {
                    colSum = $"{col}{row},";
                }
            }

            var sumOp = $"SUM({colSum})";

            worksheet.Cells[$"{colResult}{row}"].Formula = sumOp;
        }

        public static void SetValueTotalPayment(
            ExcelWorksheet worksheet,
            int row,
            List<string> cols,
            string nameColResult,
            int rowStartMerge,
            int rowMerge = 0,
            decimal? buyServiceFee = 0,
            decimal? currencyRate = 1)
        {
            var colSum = string.Empty;
            foreach (var col in cols)
            {
                if (!string.IsNullOrEmpty(colSum))
                {
                    colSum += $"{col}{row},";
                }
                else
                {
                    colSum = $"{col}{row},";
                }
            }

            var sumOp = $"SUM({colSum})";

            worksheet.Cells[$"{nameColResult}{row}"].Formula = sumOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{nameColResult}{rowStartMerge}:{nameColResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueColSumAndMergeRowResult(
            ExcelWorksheet worksheet,
            int row,
            List<string> cols,
            string nameColResult,
            int rowStartMerge,
            int rowMerge = 0)
        {
            var colSum = string.Empty;
            foreach (var col in cols)
            {
                if (!string.IsNullOrEmpty(colSum))
                {
                    colSum += $"{col}{row},";
                }
                else
                {
                    colSum = $"{col}{row},";
                }
            }

            var sumOp = $"SUM({colSum})";

            worksheet.Cells[$"{nameColResult}{row}"].Formula = sumOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{nameColResult}{rowStartMerge}:{nameColResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueColRoundAndSumRange(ExcelWorksheet worksheet, int row, string colOne, string colTwo, string colStart, string colEnd, string colResult)
        {
            var sumOp = $"SUM(PRODUCT({colOne}{row}*{colTwo}{row}),{colStart}{row}:{colEnd}{row})";

            worksheet.Cells[$"{colResult}{row}"].Formula = sumOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, int row, string colOne, string colTwo, string colResult)
        {
            var roundOp = $"PRODUCT({colOne}{row}*{colTwo}{row})";

            worksheet.Cells[$"{colResult}{row}"].Formula = roundOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult)
        {
            var roundOp = $"PRODUCT({colOne}*{colTwo})";

            worksheet.Cells[$"{colResult}"].Formula = roundOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"PRODUCT({colOne}{rowStartMerge}*{colTwo}{rowStartMerge})";

            worksheet.Cells[$"{colResult}{rowStartMerge}"].Formula = roundOp;
            if (rowMerge <= 0) return;

            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Merge = true;
            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        public static void SetValueRowRoundAndMergeRowResult(ExcelWorksheet worksheet, string colOne, string colTwo, string nameColResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"PRODUCT({colOne}*{colTwo})";
            worksheet.Cells[$"{nameColResult}{rowStartMerge}"].Formula = roundOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{nameColResult}{rowStartMerge}:{nameColResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueRowRoundWithNumber(ExcelWorksheet worksheet, string col, decimal value, string colResult)
        {
            var roundOp = $"PRODUCT({col}*{value})";

            worksheet.Cells[$"{colResult}"].Formula = roundOp;
        }

        public static void SetValueRowRoundWithNumber(ExcelWorksheet worksheet, string col, decimal value, string colResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"PRODUCT({col}{rowStartMerge}*{value})";

            worksheet.Cells[$"{colResult}{rowStartMerge}"].Formula = roundOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueRowRoundTwoColWithNumber(ExcelWorksheet worksheet, string colOne, string colTwo, decimal value, string colResult)
        {
            var roundOp = $"PRODUCT({colOne}*{colTwo}*{value})";

            worksheet.Cells[$"{colResult}"].Formula = roundOp;
        }

        public static void SetValueRow(ExcelWorksheet worksheet, int row, int col, object value, int rowMerge = 0)
        {
            worksheet.Cells[row, col].Value = value;

            if (rowMerge > 0)
            {
                worksheet.Cells[row, col, row + rowMerge, col].Merge = true;
                worksheet.Cells[row, col, row + rowMerge, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[row, col, row + rowMerge, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
        }

        public static void SetValueRow(ExcelWorksheet worksheet, string nameCol, int row, object value, int rowMerge = 0, bool customerStyle = true)
        {
            worksheet.Cells[$"{nameCol}{row}"].Value = value;
            var range = worksheet.Cells[$"{nameCol}{row}:{nameCol}{row + rowMerge}"];
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin);

            if (rowMerge <= 0) return;
            worksheet.Cells[$"{nameCol}{row}:{nameCol}{row + rowMerge}"].Merge = true;
            worksheet.Cells[$"{nameCol}{row}:{nameCol}{row + rowMerge}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            if (customerStyle)
            {
                worksheet.Cells[$"{nameCol}{row}:{nameCol}{row + rowMerge}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }
        }

        public static void SetBorderRangeRow(ExcelWorksheet worksheet, string startCol, string endCol, int startRow, int endRow)
        {
            var range = worksheet.SelectedRange[$"{startCol}{startRow}:{endCol}{endRow}"];
            range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
        }

        public static void SetValueTotalMonneyJP(ExcelWorksheet worksheet, int row, decimal? tax)
        {
            var totalMonneyJP = $"SUM(PRODUCT(F{row}*H{row}), PRODUCT(F{row}*H{row}*{(tax ?? 0M) * 0.01M}), I{row}, J{row})";

            worksheet.Cells[$"K{row}"].Formula = totalMonneyJP;
        }

        public static void SetValueTotalPrice(ExcelWorksheet worksheet, int row, decimal? price, decimal? tax, string currencyCode)
        {
            var convertValue = 1M;
            if (Utility.CurrencyConverts.Contains(currencyCode))
            {
                convertValue = 0.01M;
            }

            var totalMoneyPrice = $"SUM(PRODUCT(G{row}*{price ?? 0M}*{convertValue}), PRODUCT(G{row}*{price ?? 0M}*{(tax ?? 0M) * 0.01M}))";

            worksheet.Cells[$"K{row}"].Formula = totalMoneyPrice;
        }

        public static void AutoNumber(ExcelWorksheet worksheet, string nameCol, int row)
        {
            var autoNumberFormular = $"ROW()";
            worksheet.Cells[$"{nameCol}{row}"].Formula = autoNumberFormular;
        }

        public static void AutoHyperlink(ExcelWorksheet worksheet, string nameCol, int row, string url)
        {
            worksheet.Cells[$"{nameCol}{row}"].Hyperlink = new Uri(url, UriKind.Absolute);
            worksheet.Cells[$"{nameCol}{row}"].Style.Font.UnderLine = true;
            worksheet.Cells[$"{nameCol}{row}"].Style.Font.Color.SetColor(System.Drawing.Color.Blue);
        }

        #region Báo giá đơn ECM

        public static void SetValueTotalPriceEcm(
            ExcelWorksheet worksheet,
            int row,
            decimal? totalPriceOrder,
            int rowMerge = 0)
        {
            // Thành tiền = Tổng tiền đơn + Phí shipp nội  địa nhật + Phụ phí
            var totalMoney = $"SUM({totalPriceOrder}, L{row}, M{row})";

            worksheet.Cells[$"N{row}"].Formula = totalMoney;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"N{row}:N{row + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueTotalPriceCod(
            ExcelWorksheet worksheet,
            string currencyCode,
            string colOne,
            string colTwo,
            string colResult,
            int rowStartMerge,
            int rowMerge = 0)
        {
            var roundOp = $"PRODUCT({colOne}{rowStartMerge} * {colTwo}{rowStartMerge})";

            worksheet.Cells[$"{colResult}{rowStartMerge}"].Formula = roundOp;
            if (rowMerge <= 0) return;

            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Merge = true;
            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        public static void SetValueTotalFeeEcm(
            ExcelWorksheet worksheet,
            string currencyCode,
            string colOne,
            string colTwo,
            string nameColResult,
            int rowStartMerge,
            int rowMerge = 0)
        {

            var roundOp = $"PRODUCT({colOne} * {colTwo})";
            worksheet.Cells[$"{nameColResult}{rowStartMerge}"].Formula = roundOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{nameColResult}{rowStartMerge}:{nameColResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        #endregion

        #region Báo giá đơn VC

        public static void SetValueTotalAmount(ExcelWorksheet worksheet, int firstRowProduct, int lastRowProduct)
        {
            var sumFeeTransport = string.Empty;

            for (int i = firstRowProduct; i <= lastRowProduct; i++)
            {
                sumFeeTransport += $"K{i},";
            }

            var sumStandardFee = string.Empty;

            for (int i = firstRowProduct; i <= lastRowProduct; i++)
            {
                sumStandardFee += $"L{i},";
            }

            var totalMoneyPrice = $"SUM({sumFeeTransport} {sumStandardFee} M{firstRowProduct}, P{firstRowProduct}, Q{firstRowProduct}, R{firstRowProduct})";
            worksheet.Cells[$"S{firstRowProduct}"].Formula = totalMoneyPrice;

            if (firstRowProduct < lastRowProduct)
            {
                worksheet.Cells[$"S{firstRowProduct}:S{lastRowProduct}"].Merge = true;
            }
        }

        #endregion
    }
}
