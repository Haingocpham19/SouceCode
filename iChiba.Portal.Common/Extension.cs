using System;
using System.Text.RegularExpressions;

namespace iChiba.Portal.Common
{
    public static class Extension
    {
        public static decimal Ratio(this int field, int Sum)
        {
            if (Sum != 0)
            {
                return (decimal)field * 100 / Sum;
            }
            return 0;
        }

        public static string StringDisplayInt(this int field)
        {
            return field == 0 ? "0" : field.ToString(Constant.FORMAT_INTERGER_NUMER);
        }

        public static bool RegulardTrackingCode(string input)
        {
            var regularNumber = new Regex(@"^[0-9]+$");
            var regularLetterAndNumber = new Regex(@"^[a-zA-Z0-9]+$");
            var regularSymb = new Regex(@"^[-]+$");

            return (regularNumber.IsMatch(input) || regularLetterAndNumber.IsMatch(input) || regularSymb.IsMatch(input));
        }

        public static string StringDisplayInt(this decimal field)
        {
            return field == 0 ? "0" : field.ToString(Constant.FORMAT_INTERGER_NUMER);
        }

        public static string StringDisplayDecimal(this decimal field)
        {
            return field == 0 ? "0" : field.ToString(Constant.FORMAT_DECIMAL_NUMER);
        }

        public static string StringDisplayLong(this long field)
        {
            return field == 0 ? "0" : field.ToString(Constant.FORMAT_INTERGER_NUMER);
        }

        public static string FormatTimeSpan(this TimeSpan timeSpan)
        {
            return Utility.FormatTimeSpan(timeSpan);
        }
    }
}
