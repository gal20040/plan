using System;
using System.Globalization;
using System.Web.Mvc;

namespace IU.Plan.Web.Binding
{
    public class BrowserValueProvider : IValueProvider
    {
        private ControllerContext controllerContext { get; set; }

        public BrowserValueProvider(ControllerContext controllerContext)
        {
            this.controllerContext = controllerContext;
        }

        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("yearmonthday", prefix, true) == 0;
        }

        private int? GetIntFromRequest(string name)
        {
            var requestItem = controllerContext.RequestContext.RouteData.Values[name];
            if (requestItem == null)
            {
                requestItem = controllerContext.HttpContext.Request.Params[name];
            }

            if (requestItem == null)
            {
                return null;
            }

            var requestItemStr = requestItem.ToString();

            if (int.TryParse(requestItemStr, out int result))
            {
                return result;
            }
            return null;
        }

        public ValueProviderResult GetValue(string key)
        {
            var year = GetIntFromRequest("year") ?? DateTime.Today.Year;
            var month = GetIntFromRequest("month") ?? DateTime.Today.Month;
            var day = GetIntFromRequest("day") ?? 1;

            var value = new DateTime(year, month, day);

            return ContainsPrefix(key)
                ? new ValueProviderResult(value, null, CultureInfo.InvariantCulture)
                : null;
        }
    }
}