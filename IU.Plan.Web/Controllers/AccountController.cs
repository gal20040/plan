using IU.Plan.Core.Impl;
using IU.Plan.Web.Models;
using IU.Plan.Web.NHibernate;
using System.Web.Mvc;
using System.Web.Security;

namespace IU.Plan.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserStore store = new UserDBStore();

        ////// создаем контекст данных
        ////EventContext db = new EventContext();

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Calendar()
        //{
        //    ViewBag.Message = "Calendar page";

        //    // получаем из бд все объекты Event
        //    IEnumerable<Event> events = db.Events;
        //    // передаем все объекты в динамическое свойство Events в ViewBag
        //    ViewBag.Events = events;
        //    // возвращаем представление

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                var user = store.GetByName(model.Email);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Calendar");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка входа");
                }
            }

            return View(model);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Calendar");
        }
    }
}