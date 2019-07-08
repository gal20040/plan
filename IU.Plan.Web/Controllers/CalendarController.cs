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
            int year = 2019; //yearMonth.Year ?? yearMonth.Year;
            int month = 7;//yearMonth ?? yearMonth.Month;

            var eventFileStore = new EventFileStore();
            var firstDayOfPeriod = new DateTime(year, month, 1);
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

            //ViewBag.Browser = browser;

            return View(model);
        }
    }
}