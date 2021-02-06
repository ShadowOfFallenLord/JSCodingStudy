using JSCodingStudy.Areas.Robot.Model;
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
            IEnumerable<LessonInfo> lessons = LessonsDaoMoq.GetAllInfo();
            return View(lessons);
        }
    }
}