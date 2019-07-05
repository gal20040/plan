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
            var eventFileStore = new EventFileStore();
            var dayOfPeriod = DateTime.Now;
            var firstDayOfPeriod = new DateTime(dayOfPeriod.Year, dayOfPeriod.Month, 1);
            var lastDayOfPeriod = firstDayOfPeriod.AddMonths(1).AddDays(-1);
            var events = eventFileStore.Entities.Where(evt => evt.StartDateTime >= firstDayOfPeriod && evt.StartDateTime <= lastDayOfPeriod);

            var dayNumberOfTheFirstPeriodDay = (int)firstDayOfPeriod.DayOfWeek;
            if (dayNumberOfTheFirstPeriodDay == 0) //sunday
            {
                dayNumberOfTheFirstPeriodDay = 7;
            }

            var ColCount = 7;

            var model = new CalendarViewModel
            {
                Events = events,
                LastDayOfPeriod = lastDayOfPeriod,
                ColCount = ColCount,
                RowCount = (int)Math.Ceiling((lastDayOfPeriod.Day + dayNumberOfTheFirstPeriodDay - 1) * 1d / ColCount)
                //dayNumberOfTheFirstPeriodDay - 1 - это нужно, чтобы учесть сдвиг,
                //когда первое число месяца попадает на любой день кроме понедельника
            };

            return View(model);
        }
    }
}