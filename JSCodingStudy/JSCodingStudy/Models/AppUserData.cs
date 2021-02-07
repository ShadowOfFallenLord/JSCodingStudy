using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCodingStudy.Models
{
    public class AppUserData
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int LastRobotLesson { get; set; }
    }
}