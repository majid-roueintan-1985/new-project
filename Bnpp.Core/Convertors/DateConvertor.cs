using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bnpp.Core.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return
                pc.GetYear(value).ToString() + "/" +
                pc.GetMonth(value).ToString("00") + "/" +
                pc.GetDayOfMonth(value).ToString("00");

        }
        public static string ToShamsiDateTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return
                pc.GetHour(value).ToString("00") + ":" +
                pc.GetMinute(value).ToString("00") + ":" +
                pc.GetSecond(value).ToString("00") + "  " +
                pc.GetYear(value).ToString() + "/" +
                pc.GetMonth(value).ToString("00") + "/" +
                pc.GetDayOfMonth(value).ToString("00");

        }
        public static string ShamsiToMiladyDateTime(this string value)
        {
            //var dd=   PersianDate.Standard.ConvertDate.ToFa(DateTime.Now, "B");
            //var d = PersianDate.Standard.DateAndTimeH.GetAllFarsiMonths();
            value = value.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("v", "7").Replace("۸", "8").Replace("۹", "9");
            PersianCalendar pc = new PersianCalendar();
            string[] dateSplit = value.Split('/');
            int year = Convert.ToInt32(dateSplit[0].ToString());
            int month = Convert.ToInt32(dateSplit[1].ToString());
            int day = Convert.ToInt32(dateSplit[2].ToString());
            DateTime dt = new DateTime(year, month, day, pc);
            return dt.ToShortDateString();
        }
        public static string ToTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(value) + ":" + pc.GetMinute(value);
        }
    }
}
