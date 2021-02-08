using JSCodingStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCodingStudy.Areas.Robot.Model
{
    public class LessonData : LessonInfo
    {
        public string Task { get; set; }

        public string[] Pattern { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public bool HelpAPIMove { get; set; }
        public bool HelpAPICheck { get; set; }
        public bool HelpAPIDraw { get; set; }

        public string Code { get; set; }
    }
}