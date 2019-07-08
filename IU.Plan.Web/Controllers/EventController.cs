using System;
using System.Web.Mvc;
using IU.PlanManager.Core.Impl;
using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;

namespace IU.Plan.Web.Controllers
{
    public class EventController : Controller
    {
        private IStore<Event> store = new EventFileStore();

        // GET: Event
        public ActionResult Details(Guid uid)
        {
            var evnt = store.Get(uid);

            return View(evnt);
        }

        public PartialViewResult View(Guid uid)
        {
            var evnt = store.Get(uid);

            return PartialView("Details", evnt);
        }
    }
}