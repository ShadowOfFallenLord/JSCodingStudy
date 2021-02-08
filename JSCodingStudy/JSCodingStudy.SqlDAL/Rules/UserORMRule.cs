using JSCodingStudy.SqlTools.ORM.Rules;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlDAL.Rules
{
    public class UserORMRule : TypeRule
    {
        public UserORMRule() : base(typeof(User))
        {
            User item = new User();

            AddIntProperty(nameof(item.Id), "Id");
            AddStringProperty(nameof(item.Login), "Login");
            AddStringProperty(nameof(item.Password), "Password");
            AddIntProperty(nameof(item.RobotLastLesson), "RobotLastLesson");
        }

        public static UserORMRule Instance { get; } = new UserORMRule();
    }
}
