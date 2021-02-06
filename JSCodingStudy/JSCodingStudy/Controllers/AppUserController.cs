using JSCodingStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JSCodingStudy.Controllers
{
    public class AppUserController : Controller
    {
        // GET: AppUser
        public ActionResult Index()
        {
            IEnumerable<AppUserData> users = AppUserDaoMoq.GetAll();
            return View(users);
        }

        #region Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "Login, Password")] AppUserData model)
        {
            if (AppUserDaoMoq.HasCheck(model.Login))
            {
                ModelState.AddModelError("Login", "User alredy exist");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bad login/password");
                return View(model);
            }

            AppUserData user = AppUserDaoMoq.Add(model.Login, model.Password);
            FormsAuthentication.SetAuthCookie(user.Login, true);

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Login, Password")] AppUserData model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bad login/password");
                return View(model);
            }

            AppUserData user = AppUserDaoMoq.Find(model.Login, model.Password);
            if (user is null)
            {
                ModelState.AddModelError("Login", "Unknown login");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(user.Login, true);
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}