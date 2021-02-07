using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LessonsEntities.Robot
{
    public class RobotLessonData : BaseLesson
    {
        public string Task { get; set; }

        public string[] Pattern { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public RobotAPIHelpReference APIHelp { get; set; }
    }
}
