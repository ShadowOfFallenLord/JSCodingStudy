using JSCodingStudy.Areas.Robot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSCodingStudy.Areas.Robot.Controllers
{
    public class LessonController : Controller
    {
        // GET: Robot/Lesson
        public ActionResult Sandbox()
        {
            return View();
        }

        // GET: Robot/Lesson
        public ActionResult Lesson(int id)
        {
            LessonData lesson = LessonsDaoMoq.GetLessonById(id);
            return View(lesson);
        }
    }
}