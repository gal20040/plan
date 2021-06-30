using IU.Plan.Web.NH;
using IU.PlanManager.Core.Models;
using System.Web.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class SearchController : Controller
    {
        private IEventStore<Event> store = new EventDBStore<Event>();

        [HttpPost]
        public ActionResult Filter(string searchRequest)
        {
            var result = store.Find(searchRequest);

            return PartialView("List", result);
        }
    }
}