using IU.Plan.Web.NHibernate;
using IU.Plan.Core.Interfaces;
using IU.Plan.Core.Models;
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

            var eventCount = store.Entities.Count(evt => evt.StartDateTime >= tomorrow && evt.StartDateTime < aftertomorrow);

            return eventCount;
        }
    }
}