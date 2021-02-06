using JSCodingStudy.Areas.Robot.Model;
using JSCodingStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSCodingStudy.Areas.Robot.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        // GET: Robot/Menu
        public ActionResult Index()
        {
            AppUserData user = AppUserDaoMoq.Find(HttpContext.User.Identity.Name);
            IEnumerable<LessonInfo> lessons = LessonsDaoMoq
                .GetAllInfo()
                .Where(x => x.Id <= user.LastRobotLesson);
            return View(lessons);
        }
    }
}