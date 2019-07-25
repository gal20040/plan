using System;
using System.Web.Mvc;
using IU.Plan.Web.Models;
using IU.Plan.Web.NH;
using IU.PlanManager.ConApp;
using IU.PlanManager.Extensions;

namespace IU.Plan.Web.Controllers
{
    public class ActivityController : Controller
    {
        private IStore<Activity> store = new EventDBStore<Activity>();

        public PartialViewResult MiniDetails(Guid uid)
        {
            var evt = store.Get(uid);

            return PartialView("Details", evt);
        }

        // GET: Event
        public PartialViewResult Create()
        {
            var evt = new Activity();

            var model = new ActivityEditModel(evt);

            return PartialView("Edit", model);
        }

        // GET: Event
        public PartialViewResult Edit(Guid uid)
        {
            var evt = store.Get(uid);

            var model = new ActivityEditModel(evt);

            return PartialView("Edit", model);
        }

        [HttpPost]
        public PartialViewResult Save(ActivityEditModel model)
        {
            if (ModelState.IsValid)
            {
                var evt = model.GetEvent();
                try
                {
                    store.Update(evt);
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
                return Json(new { Result = "Ok"} );
            }
            catch(Exception ex)
            {
                return Json(new { Error = ex.Message });
            }
        }
    }
}