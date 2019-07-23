using IU.Plan.Core.Interfaces;
using IU.Plan.Web.Extensions;
using IU.Plan.Web.Models;
using IU.Plan.Web.NHibernate;
using System;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class MeetingController : Controller
    {
        private IStore<Meeting> store = new EventDBStore<Meeting>();

        public PartialViewResult MiniDetails(Guid uid)
        {
            var evt = store.Get(uid);

            return PartialView("Details", evt);
        }

        // GET: Event
        public PartialViewResult Create()
        {
            var evt = new Meeting();

            var model = new MeetingEditModel(evt);

            return PartialView("Edit", model);
        }

        // GET: Event
        public PartialViewResult Edit(Guid uid)
        {
            var evt = store.Get(uid);

            var model = new MeetingEditModel(evt);

            return PartialView("Edit", model);
        }

        [HttpPost]
        public PartialViewResult Save(MeetingEditModel model)
        {
            if (ModelState.IsValid)
            {
                var evt = model.GetEvent();
                try
                {
                    store.UpdateByGuid(evt);
                    ViewBag.SaveResult = "Успешно сохранено";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return PartialView("Edit", model);
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
    }
}