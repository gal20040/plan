using System;
using System.Linq;
using IU.PlanManager.Core.Impl;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            var eventFileStore = new EventFileStore();
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var model = eventFileStore.Entities.Where(evt => evt.StartDateTime >= firstDayOfMonth && evt.StartDateTime <= lastDayOfMonth);

            return View(model);
        }
    }
}