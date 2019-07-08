using System;
using System.Globalization;
using System.Web.Mvc;

namespace IU.Plan.Web.Bindings
{
    public class BrowserValueProvider : IValueProvider
    {
        private ControllerContext ControllerContext { get; set; }

        public BrowserValueProvider(ControllerContext controllerContext)
        {
            ControllerContext = controllerContext;
        }

        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("yearmonthday", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            var yearStr = ControllerContext.RequestContext.RouteData.Values["year"];
            var monthStr = ControllerContext.RequestContext.RouteData.Values["month"];
            var dayStr = ControllerContext.RequestContext.RouteData.Values["day"];

            if (yearStr == null || !int.TryParse(yearStr.ToString(), out int year))
            {
                year = DateTime.Today.Year;
            }

            if (monthStr == null || !int.TryParse(monthStr.ToString(), out int month))
            {
                month = DateTime.Today.Month;
            }

            if (dayStr == null || !int.TryParse(dayStr.ToString(), out int day))
            {
                day = DateTime.Today.Day;
            }

            var value = new DateTime(year, month, day);

            return ContainsPrefix(key)
                ? new ValueProviderResult(value, null, CultureInfo.InvariantCulture)
                : null;
        }
    }
}