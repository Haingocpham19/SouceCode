using System.Data;

namespace iChiba.Portal.Common
{
    public static class DataTableExtensions
    {
        public static void NormalizeImportFrom(this DataTable dtData, DataTable dtExport)
        {
            foreach (DataRow row in dtExport.Rows)
            {
                if (row.IsEmptyRow())
                    continue;
                dtData.ImportRow(row);
            }
        }

        public static bool IsEmptyRow(this DataRow row, bool trim = true)
        {
            var cellVal = "";
            var isEmptyRow = true;
            var dt = row.Table;
            foreach (DataColumn col in dt.Columns)
            {
                var cell = row[col.ColumnName];
                cellVal = trim ? cell.ToString()?.Trim() : cell.ToString();
                cell = cellVal;
                if (!cellVal.IsEmptyCellValue())
                {
                    isEmptyRow = false;
                    break;
                }
            }

            return isEmptyRow;
        }

        public static bool IsEmptyCellValue(this string cellValue)
        {
            return string.IsNullOrWhiteSpace(cellValue) || cellValue == "#N/A";
        }

        public static string NormalizeCellValue(this string cellValue)
        {
            if (cellValue == "#N/A")
                cellValue = "";
            else if (!string.IsNullOrEmpty(cellValue))
                cellValue = cellValue.Trim();

            return cellValue;
        }
    }
}
