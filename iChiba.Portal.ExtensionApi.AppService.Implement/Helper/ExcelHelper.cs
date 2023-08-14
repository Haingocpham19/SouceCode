using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.ExtensionApi.AppService.Implement.Adapter
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

        public static object SetValueRowSumAndGetValue(ExcelWorksheet worksheet, int rowStart, int rowEnd, string col)
        {
            var sumOp = $"SUM({col}{rowStart}:{col}{rowEnd - 1})";

            worksheet.Cells[$"{col}{rowEnd}"].Formula = sumOp;
            return worksheet.Cells[$"{col}{rowEnd}"].Value;
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

            // Phí thanh toán
            //colSum += $"(ROUND(P{row}*L{row},0))";
            colSum += $"P{row}";

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
            var sumOp = $"SUM(ROUND({colOne}{row}*{colTwo}{row},0),{colStart}{row}:{colEnd}{row})";

            worksheet.Cells[$"{colResult}{row}"].Formula = sumOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, int row, string colOne, string colTwo, string colResult)
        {
            var roundOp = $"ROUND({colOne}{row}*{colTwo}{row},0)";

            worksheet.Cells[$"{colResult}{row}"].Formula = roundOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult)
        {
            var roundOp = $"ROUND({colOne}*{colTwo},0)";

            worksheet.Cells[$"{colResult}"].Formula = roundOp;
        }

        public static void SetValueRowRound(ExcelWorksheet worksheet, string colOne, string colTwo, string colResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"ROUND({colOne}{rowStartMerge}*{colTwo}{rowStartMerge},0)";

            worksheet.Cells[$"{colResult}{rowStartMerge}"].Formula = roundOp;
            if(rowMerge<= 0) return;

            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Merge = true;
            worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        public static void SetValueRowRoundAndMergeRowResult(ExcelWorksheet worksheet, string colOne, string colTwo, string nameColResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"ROUND({colOne}*{colTwo},0)";
            worksheet.Cells[$"{nameColResult}{rowStartMerge}"].Formula = roundOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{nameColResult}{rowStartMerge}:{nameColResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueRowRoundWithNumber(ExcelWorksheet worksheet, string col, decimal value, string colResult)
        {
            var roundOp = $"ROUND({col}*{value},0)";

            worksheet.Cells[$"{colResult}"].Formula = roundOp;
        }

        public static void SetValueRowRoundWithNumber(ExcelWorksheet worksheet, string col, decimal value, string colResult, int rowStartMerge, int rowMerge = 0)
        {
            var roundOp = $"ROUND({col}{rowStartMerge}*{value},0)";

            worksheet.Cells[$"{colResult}{rowStartMerge}"].Formula = roundOp;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"{colResult}{rowStartMerge}:{colResult}{rowStartMerge + rowMerge}"].Merge = true;
            }
        }

        public static void SetValueRowRoundTwoColWithNumber(ExcelWorksheet worksheet, string colOne, string colTwo, decimal value, string colResult)
        {
            var roundOp = $"ROUND({colOne}*{colTwo}*{value},0)";

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
            var totalMonneyJP = $"SUM(ROUND(F{row}*H{row},0), ROUND(F{row}*H{row}*{(tax ?? 0M) * 0.01M},0), I{row}, J{row})";

            worksheet.Cells[$"K{row}"].Formula = totalMonneyJP;
        }

        public static void SetValueTotalPrice(ExcelWorksheet worksheet, int row, decimal? price, decimal? tax)
        {
            var totalMoneyPrice = $"SUM(ROUND(F{row}*{price ?? 0M},0), ROUND(F{row}*{price ?? 0M}*{(tax ?? 0M) * 0.01M},0))";

            worksheet.Cells[$"H{row}"].Formula = totalMoneyPrice;
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

        public static void SetValueTotalPriceEcm(ExcelWorksheet worksheet, int row, decimal? totalPriceOrder, int rowMerge = 0)
        {
            // Thành tiền = Tổng tiền đơn + Phí shipp nội  địa nhật + Phụ phí
            var totalMoney = $"SUM({totalPriceOrder}, I{row}, J{row})";

            worksheet.Cells[$"K{row}"].Formula = totalMoney;

            if (rowMerge > 0)
            {
                worksheet.Cells[$"K{row}:K{row + rowMerge}"].Merge = true;
            }
        }

        #endregion

        #region Báo giá đơn VC

        public static void SetValueTotalAmount(ExcelWorksheet worksheet, int firstRowProduct, int lastRowProduct)
        {
            var sumFeeTransport = string.Empty;

            for (int i = firstRowProduct; i <= lastRowProduct; i++)
            {
                sumFeeTransport += $"J{i},";
            }

            var sumStandardFee = string.Empty;

            for (int i = firstRowProduct; i <= lastRowProduct; i++)
            {
                sumStandardFee += $"K{i},";
            }

            var totalMoneyPrice = $"SUM({sumFeeTransport} {sumStandardFee} L{firstRowProduct}, O{firstRowProduct}, P{firstRowProduct}, Q{firstRowProduct})";
            worksheet.Cells[$"R{firstRowProduct}"].Formula = totalMoneyPrice;

            if (firstRowProduct < lastRowProduct)
            {
                worksheet.Cells[$"R{firstRowProduct}:R{lastRowProduct}"].Merge = true;
            }
        }

        #endregion
    }
}
