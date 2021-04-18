using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSCodingStudy.MemoryDAL.Robot;

namespace JSCodingStudy.MemoryDAL
{
    public class UserCodeDao<LessonType> : IUserCodeDao<LessonType> where LessonType : ILesson
    {
        private Dictionary<int, Dictionary<int, string>> codes;

        public UserCodeDao()
        {
            codes = new Dictionary<int, Dictionary<int, string>>();
            InitResolvedLessons();
        }

        private void InitResolvedLessons()
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

        public bool Add(int user_id, int lesson_id, string code)
        {
            if (CheckHas(user_id, lesson_id))
            {
                return false;
            }

            this[user_id, lesson_id] = code;
            return true;
        }

        public string GetById(int user_id, int lesson_id)
        {
            return this[user_id, lesson_id];
        }

        public bool Update(int user_id, int lesson_id, string code)
        {
            if (CheckHas(user_id, lesson_id))
            {
                this[user_id, lesson_id] = code;
                return true;
            };
            return false;
        }

        protected string this[int user_id, int lesson_id]
        {
            get
            {
                if (!codes.ContainsKey(user_id))
                {
                    codes.Add(user_id, new Dictionary<int, string>());
                }

                if (codes[user_id].ContainsKey(lesson_id))
                {
                    return codes[user_id][lesson_id];
                }

                return "";
            }
            set
            {
                if (!codes.ContainsKey(user_id))
                {
                    codes.Add(user_id, new Dictionary<int, string>());
                }

                if (!codes[user_id].ContainsKey(lesson_id))
                {
                    codes[user_id].Add(lesson_id, null);
                }

                codes[user_id][lesson_id] = value;
            }
        }

        protected bool CheckHas(int user_id, int lesson_id)
        {
            if (!codes.ContainsKey(user_id))
            {
                return false;
            }

            if (!codes[user_id].ContainsKey(lesson_id))
            {
                return false;
            }

            return true;
        }
    }
}
