using JSCodingStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCodingStudy.Areas.Robot.Model
{
    public class APIReference
    {
        public bool Move { get; set; }
        public bool Check { get; set; }
        public bool Draw { get; set; }
    }

    public class LessonData : LessonInfo
    {
        public string Task { get; set; }

        public string[] Pattern { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public APIReference APIHelp { get; set; }

        public string Code { get; set; }
    }
}