using IU.Plan.Web.Models;
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

        // GET: Event
        public PartialViewResult Edit(Guid uid)
        {
            var evnt = store.Get(uid);

            var model = new EventEditModel(evnt);

            return PartialView("EventEdit", model);
        }

        public PartialViewResult EventEdit(Guid uid)
        {

            return PartialView("EventEdit");
        }

        [HttpPost]
        public PartialViewResult Save(EventEditModel model)
        {
            if (ModelState.IsValid)
            {
                var evnt = model.GetEvent();
                try
                {
                    store.UpdateByGuid(evnt);
                    ViewBag.SaveResult = "Успешно сохранено";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return PartialView("EventEdit", model);
        }

        [HttpPost]
        public PartialViewResult Delete(Guid uid)
        {
            //if (ModelState.IsValid)
            //{
            //    var evnt = model.GetEvent();
                try
                {
                    store.Delete(uid);
                    ViewBag.DeleteResult = "Успешно удалено";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            //}

            return PartialView("Delete");
        }
    }
}