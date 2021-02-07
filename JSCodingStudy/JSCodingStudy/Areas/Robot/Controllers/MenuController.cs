using JSCodingStudy.Areas.Robot.Model;
using JSCodingStudy.LessonsEntities.Robot;
using JSCodingStudy.LogicInterfaces;
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
        private IUserLogic user_logic;
        private ILessonLogic<RobotLessonData> lessons_logic;

        public MenuController(IUserLogic user_logic, ILessonLogic<RobotLessonData> lessons_logic)
        {
            this.user_logic = user_logic;
            this.lessons_logic = lessons_logic;
        }

        // GET: Robot/Menu
        public ActionResult Index()
        {
            UserEntities.User user = user_logic.GetByLogin(HttpContext.User.Identity.Name);
            IEnumerable<LessonInfo> lessons = lessons_logic
                .GetAvailable(user)
                .Select(x => new LessonInfo
                {
                    Id = x.Id,
                    Title = x.Title
                });
            return View(lessons);
        }
    }
}