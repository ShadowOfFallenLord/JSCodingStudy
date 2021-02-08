using JSCodingStudy.LessonsEntities.Robot;
using JSCodingStudy.SqlTools.ORM.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlDAL.Rules
{
    public class RobotLessonORMRule : TypeRule
    {
        public RobotLessonORMRule() : base(typeof(RobotLessonData))
        {
            RobotLessonData item = new RobotLessonData();

            AddIntProperty(nameof(item.Id), "Id");
            //AddStringProperty(nameof(item.Title), "Title");
            //AddStringProperty(nameof(item.Task), "Task");
            //AddStringProperty(nameof(item.Pattern), "Pattern");
            AddIntProperty(nameof(item.StartX), "StartX");
            AddIntProperty(nameof(item.StartY), "StartY");
            //AddIntProperty(nameof(item.HelpAPIMove), "HelpAPIMove");
            //AddIntProperty(nameof(item.HelpAPICheck), "HelpAPICheck");
            //AddIntProperty(nameof(item.HelpAPIDraw), "HelpAPIDraw");
        }

        public static RobotLessonORMRule Instance { get; } = new RobotLessonORMRule();
    }
}
