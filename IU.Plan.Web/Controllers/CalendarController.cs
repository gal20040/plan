using IU.Plan.Web.Extensions;
using IU.Plan.Web.Models;
using IU.Plan.Web.NHibernate;
using IU.PlanManager.Core.Impl;
using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;
using IU.PlanManager.Extensions;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        private IStore<Event> eventStore = new EventFileStore();
        private IStore<Activity> activityStore = new BaseFileStore<Activity>();


        // GET: Calendar
        public ActionResult Index(DateTime yearMonthDay)
        {
            var eventFileStore = new EventFileStore();
            var beginOfPeriod = new DateTime(yearMonthDay.Year, yearMonthDay.Month, 1);
            var endOfPeriod = beginOfPeriod.AddMonths(1).AddMilliseconds(-1);
            var events = eventStore.Entities.Where(evt =>
                evt.StartDateTime != null
                    && evt.StartDateTime.Value.Year == beginOfPeriod.Year
                    && evt.StartDateTime.Value.Month == beginOfPeriod.Month
                ).ToList();

            events.AddRange(activityStore.Entities.Where(evt =>
                evt.StartDateTime != null
                && evt.StartDateTime.Value.Year == beginOfPeriod.Year
                && evt.StartDateTime.Value.Month == beginOfPeriod.Month)
            );

            var session = NHibernateHelper.GetCurrentSession();
            try
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(events[0]);
                    tx.Commit();
                }
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }

            var colCount = 7;

            var model = new CalendarViewModel
            {
                Events = events,
                BeginOfPeriod = beginOfPeriod,
                EndOfPeriod = endOfPeriod,
                ColCount = colCount,
                RowCount = (int)Math.Ceiling((endOfPeriod.Day + beginOfPeriod.DayOfWeek.ToInt()) * 1d / colCount)
                //dayNumberOfTheFirstPeriodDay - 1 - нужно, чтобы учесть сдвиг,
                //когда первое число месяца попадает на любой день кроме понедельника
            };

            //ViewBag.Browser = browser;

            return View(model);
        }
    }
}