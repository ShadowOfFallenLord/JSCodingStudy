using JSCodingStudy.LogicInterfaces;
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
        private IUserLogic logic;

        public AppUserController(IUserLogic logic)
        {
            this.logic = logic;
        }

        // GET: AppUser
        public ActionResult Index()
        {
            IEnumerable<AppUserData> users = logic
                .GetAll()
                .Select(x => new AppUserData
                {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    LastRobotLesson = x.RobotLastLesson
                });
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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bad login/password");
                return View(model);
            }

            UserEntities.User user = new UserEntities.User
            {
                Login = model.Login,
                Password = model.Password
            };

            if (logic.Add(user))
            {
                FormsAuthentication.SetAuthCookie(user.Login, true);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Login", "User alredy exist");
            return View(model);
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

            UserEntities.User user = logic.GetByLogin(model.Login);
            if (user is null)
            {
                ModelState.AddModelError("Login", "Unknown login");
                return View(model);
            }

            if(user.Password != model.Password)
            {
                ModelState.AddModelError("Login", "Bad password");
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