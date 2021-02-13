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
    public class LessonsController : Controller
    {
        private IUserLogic user_logic;
        private ILessonLogic<RobotLessonData> lessons_logic;
        private IUserCodeLogic<RobotLessonData> code_logic;

        public LessonsController(IUserLogic user_logic, ILessonLogic<RobotLessonData> lessons_logic, IUserCodeLogic<RobotLessonData> code_logic)
        {
            this.user_logic = user_logic;
            this.lessons_logic = lessons_logic;
            this.code_logic = code_logic;
        }

        // GET: Robot/Lesson
        public ActionResult Sandbox()
        {
            return View();
        }

        // GET: Robot/Lesson
        public ActionResult Lesson(int id)
        {
            UserEntities.User user = user_logic.GetByLogin(HttpContext.User.Identity.Name);

            RobotLessonData data = lessons_logic.GetById(id);
            string code = code_logic.Get(user.Id, id);

            LessonData lesson = new LessonData
            {
                Id = data.Id,
                Title = data.Title,

                Task = data.Task,
                Pattern = data.Pattern,
                StartX = data.StartX,
                StartY = data.StartY,

                HelpAPIMove = data.HelpAPIMove,
                HelpAPICheck = data.HelpAPICheck,
                HelpAPIDraw = data.HelpAPIDraw,

                Code = code
            };

            return View(lesson);
        }

        [HttpPost]
        public ActionResult SuccessLesson(int id)
        {
            UserEntities.User user = user_logic.GetByLogin(HttpContext.User.Identity.Name);
            bool flag = false;

            if(user.RobotLastLesson == id)
            {
                user.RobotLastLesson++;
                flag = user_logic.UpdateLessons(user);
            }

            if(!flag)
            {
                user.RobotLastLesson--;
            }

            return Json(new { success = true, updated = flag });
        }

        [HttpPost]
        public ActionResult SaveCode(int id, string code)
        {
            UserEntities.User user = user_logic.GetByLogin(HttpContext.User.Identity.Name);

            bool flag = code_logic.Set(user.Id, id, code);

            return Json(new { success = true, updated = flag });
        }
    }
}