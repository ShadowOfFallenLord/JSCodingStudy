using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LessonsEntities.Robot
{
    public class LessonData : ILesson
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Task { get; }

        public string[] Pattern { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public APIHelpReference APIHelp { get; set; }
    }
}
