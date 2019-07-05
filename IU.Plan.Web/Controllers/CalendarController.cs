using IU.Plan.Web.Models;
using IU.PlanManager.Core.Impl;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            int year = -1, month = -1;
            var yearParam = RouteData.Values["year"];
            var monthParam = RouteData.Values["month"];

            int.TryParse(yearParam == null ? "" : yearParam.ToString(), out year);
            int.TryParse(monthParam == null ? "" : monthParam.ToString(), out month);

            if (year <= 1900 || year >= 2100 || !(month >= 1 && month <= 12))
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
            }
            var dayOfPeriod = new DateTime(year, month, 1);

            var eventFileStore = new EventFileStore();
            var firstDayOfPeriod = new DateTime(dayOfPeriod.Year, dayOfPeriod.Month, 1);
            var lastMomentOfPeriod = firstDayOfPeriod.AddMonths(1).AddMilliseconds(-1);
            var events = eventFileStore.Entities.Where(evt => evt.StartDateTime >= firstDayOfPeriod && evt.StartDateTime <= lastMomentOfPeriod);

            var dayNumberOfTheFirstPeriodDay = (int)firstDayOfPeriod.DayOfWeek;
            if (dayNumberOfTheFirstPeriodDay == 0) //sunday
            {
                dayNumberOfTheFirstPeriodDay = 7;
            }

            var ColCount = 7;

            var model = new CalendarViewModel
            {
                Events = events,
                LastMomentOfPeriod = lastMomentOfPeriod,
                ColCount = ColCount,
                RowCount = (int)Math.Ceiling((lastMomentOfPeriod.Day + dayNumberOfTheFirstPeriodDay - 1) * 1d / ColCount)
                //dayNumberOfTheFirstPeriodDay - 1 - это нужно, чтобы учесть сдвиг,
                //когда первое число месяца попадает на любой день кроме понедельника
            };

            return View(model);
        }
    }
}