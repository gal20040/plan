using IU.Plan.Web.Models;
using IU.Plan.Web.NHibernate;
using IU.Plan.Core.Interfaces;
using IU.Plan.Core.Models;
using System;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class EventController : Controller
    {
        private IStore<Event> store = new EventDBStore<Event>();

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
        public JsonResult Delete(Guid uid)
        {
            try
            {
                store.Delete(uid);
                return Json(new { Result = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }

        // GET: Event
        public PartialViewResult Create()
        {
            var evt = new Event();

            var model = new EventEditModel(evt);

            return PartialView("EventEdit", model);
        }
    }
}