using System.Web.Mvc;
using System.Web.Security;
using IU.Plan.Web.Models;
using IU.Plan.Web.NH;
using IU.PlanManager.ConApp;

namespace IU.Plan.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserStore store = new UserDBStore();

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