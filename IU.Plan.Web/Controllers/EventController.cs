using IU.PlanManager.Core.Impl;
using IU.PlanManager.Core.Interfaces;
using IU.PlanManager.Core.Models;
using System;
using System.Web.Mvc;

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

        public PartialViewResult MiniDetails(Guid uid)
        {
            var evnt = store.Get(uid);

            return PartialView("Details", evnt);
        }

        public PartialViewResult Edit(Guid uid)
        {
            var evnt = store.Get(uid);

            return PartialView("Edit", evnt);
        }
    }
}