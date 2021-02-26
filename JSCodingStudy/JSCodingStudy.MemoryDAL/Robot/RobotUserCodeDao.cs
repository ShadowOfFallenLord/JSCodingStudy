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
            this[UserDao.FullUser.Id, 1] = "Robot.Move(Directions.Up)\n" +
                                           "Robot.Move(Directions.Down)\n" +
                                           "Robot.Move(Directions.Down)";

            this[UserDao.FullUser.Id, 2] = "Robot.Move(Directions.Left)\n" +
                                           "Robot.Move(Directions.Right)\n" +
                                           "Robot.Move(Directions.Right)";

            this[UserDao.FullUser.Id, 3] = "Robot.Move(Directions.Up)\n" +
                                           "Robot.Move(Directions.Up)\n" +
                                           "Robot.Move(Directions.Right)\n" +
                                           "Robot.Move(Directions.Right)\n" +
                                           "Robot.Move(Directions.Down)\n" +
                                           "Robot.Move(Directions.Down)\n" +
                                           "Robot.Move(Directions.Left)";
        }
    }
}
