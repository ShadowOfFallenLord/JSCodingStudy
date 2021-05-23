using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSCodingStudy.LessonsEntities.Robot;

namespace JSCodingStudy.MemoryDAL.Robot
{
    public class RobotUserCodeDao : UserCodeDao<RobotLessonData>
    {
        public RobotUserCodeDao() : base()
        {
            this[UserDao.FullUser.Id, RobotLessonDao.Lesson1.Id] =
                "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Down);";

            this[UserDao.FullUser.Id, RobotLessonDao.Lesson2.Id] =
                "Robot.Move(Directions.Left);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Right);";

            this[UserDao.FullUser.Id, RobotLessonDao.Lesson3.Id] =
                "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Left);";

            this[UserDao.FullUser.Id, RobotLessonDao.Lesson4.Id] =
                "for(var i = 1; i < 10; i++)\n" +
                "   Robot.Move(Directions.Right);\n" +
                "for (var i = 1; i < 5; i++)\n" +
                "   Robot.Move(Directions.Down);\n" +
                "for (var i = 1; i < 10; i++)\n" +
                "   Robot.Move(Directions.Left);\n" +
                "for (var i = 1; i < 5; i++)\n" +
                "   Robot.Move(Directions.Up);";

            this[UserDao.FullUser.Id, RobotLessonDao.Lesson5.Id] =
                "for(var i = 0; i < 3; i++)\n" +
                "{\n" +
                "   for (var j = 0; j < 9 - i - i; j++)\n" +
                "       Robot.Move(Directions.Right);\n" +
                "   for (var j = 0; j < 4 - i - i; j++)\n" +
                "       Robot.Move(Directions.Down);\n" +
                "   for (var j = 0; j < 9 - i - i - 1; j++)\n" +
                "       Robot.Move(Directions.Left);\n" +
                "   for (var j = 0; j < 4 - i - i - 1; j++)\n" +
                "       Robot.Move(Directions.Up);\n" +
                "}";
        }
    }
}
