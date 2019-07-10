//using IU.Plan.Web.Models;
//using IU.PlanManager.Core.Models;
//using System.Collections.Generic;
//using System.Web.Mvc;

//namespace IU.Plan.Web.Controllers
//{
//    public class HomeController : Controller
//    {
//        // создаем контекст данных
//        EventContext db = new EventContext();

//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult About()
//        {
//            ViewBag.Message = "Your application description page.";

//            return View();
//        }

//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }

//        public ActionResult Calendar()
//        {
//            ViewBag.Message = "Calendar page";

//            // получаем из бд все объекты Event
//            IEnumerable<Event> events = db.Events;
//            // передаем все объекты в динамическое свойство Events в ViewBag
//            ViewBag.Events = events;
//            // возвращаем представление

//            return View();
//        }
//    }
//}