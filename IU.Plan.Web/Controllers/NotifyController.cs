using IU.Plan.Web.NH;
using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class NotifyController : Controller
    {
        private IStore<Event> store = new EventDBStore<Event>();

        // GET: Notify
        public long Info(bool isToday = false)
        {
            var tomorrow = DateTime.Today.AddDays(isToday ? 0 : 1);
            var aftertomorrow = tomorrow.AddDays(1);

            var eventCount = store.Entities.Count(evt => evt.StartDate >= tomorrow && evt.StartDate < aftertomorrow);

            return eventCount;
        }
    }
}