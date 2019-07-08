//using System;
//using System.Globalization;
//using System.Web;
//using System.Web.Mvc;

//namespace IU.Plan.Web.Bindings
//{
//    public class BrowserValueProvider : IValueProvider
//    {
//        public bool ContainsPrefix(string prefix)
//        {
//            return string.Compare("yearmonthday", prefix, true) == 0;
//        }

//        public ValueProviderResult GetValue(string key)
//        {
//            var yearStr = HttpContext.Current.Request.Params["year"];
//            var monthStr = HttpContext.Current.Request.Params["month"];

//            if (!int.TryParse(yearStr, out int year))
//            {
//                year = DateTime.Today.Year;
//            }

//            if (!int.TryParse(monthStr, out int month))
//            {
//                month = DateTime.Today.Month;
//            }

//            var value = new DateTime(year, month, 1);

//            return ContainsPrefix(key)
//                ? new ValueProviderResult(value, null, CultureInfo.InvariantCulture)
//                : null;
//        }
//    }
//}