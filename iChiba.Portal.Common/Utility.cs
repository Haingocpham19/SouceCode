using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.Portal.Common
{
    public static class Utility
    {
        public static List<string> CurrencyConverts = new List<string>
        {
            "USD", "GBP", "EUR"
        };
        public static string CreateFullFileUrl(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return filePath;
            }

            return $"{ConfigSettingDefine.CdnDomain.GetConfig()}{filePath}";
        }

        public static string FormatTimeSpan(TimeSpan timeSpan)
        {
            //Func<string, string> formatFunc = (format) => timeSpan.ToString(format);
            //var result = $"{formatFunc("dd")}:{formatFunc("hh")}:{formatFunc("mm")}:{formatFunc("ss")}";
            var result = timeSpan.ToString(@"dd\.hh\:mm\:ss");

            return result;
        }

        public static float? GetPriceForUS(string currency, long? value)
        {
            if (value == null) return 0;
            var result = (float)value;
            if (CurrencyConverts.Contains(currency))
            {
                result = result / 100f;
            }
            return result;
        }

        public static long? PostPriceForUS(string currency, float? value)
        {
            if (value == null) return 0;
            var result = value;
            if (CurrencyConverts.Contains(currency))
            {
                result = result * 100L;
            }
            return (long)result;
        }

        public static long GetPriceVND(float? value, int exchangeRate)
        {
            if (value == null) return 0;
            return (long)Math.Round((decimal)(value * exchangeRate), MidpointRounding.AwayFromZero);
        }

        public static decimal GetWeightOrder(int? weight, int? length, int? width, int? height)
        {
            var result = ((decimal)(weight ?? 0)) / 1000;
            var weightDim = ((decimal)((length ?? 0) * (width ?? 0) * (height ?? 0))) / 6000;
            if (weightDim > result) result = weightDim;
            return result;
        }

        public static string GetDateDisplay(DateTime date)
        {
            var dayOfWeek = string.Empty;
            var diff = DateTime.UtcNow.Subtract(date).Days;
            if (diff == 0) dayOfWeek = "Hôm nay";
            else if (diff == 1) dayOfWeek = "Hôm qua";
            else if (diff > 1 && diff < 5) dayOfWeek = date.DayOfWeek.ToString();
            else dayOfWeek = string.Empty;

            if (string.IsNullOrEmpty(dayOfWeek))
            {
                return $"Ngày {date.Day} tháng {date.Month} năm {date.Year}";
            }
            else
            {
                return $"{dayOfWeek}, ngày {date.Day} tháng {date.Month} năm {date.Year}";
            }
        }
    }
}
