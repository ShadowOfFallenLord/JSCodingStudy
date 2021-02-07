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
    public class LessonsController : Controller
    {
        // GET: Robot/Lesson
        public ActionResult Sandbox()
        {
            return View();
        }

        // GET: Robot/Lesson
        public ActionResult Lesson(int id)
        {
            AppUserData user = AppUserDaoMoq.Find(HttpContext.User.Identity.Name);
            LessonData lesson = LessonsDaoMoq.GetLessonById(id);
            lesson.Code = UserCodeDaoMoq.Get(user.Id, id);
            return View(lesson);
        }

        [HttpPost]
        public ActionResult SuccessLesson(int id)
        {
            AppUserData user = AppUserDaoMoq.Find(HttpContext.User.Identity.Name);
            bool flag = false;
            if(user.LastRobotLesson == id)
            {
                user.LastRobotLesson++;
                flag = true;
            }
            return Json(new { success = true, updated = flag });
        }

        [HttpPost]
        public ActionResult SaveCode(int id, string code)
        {
            AppUserData user = AppUserDaoMoq.Find(HttpContext.User.Identity.Name);
            UserCodeDaoMoq.Set(user.Id, id, code);
            return Json(new { success = true });
        }
    }
}