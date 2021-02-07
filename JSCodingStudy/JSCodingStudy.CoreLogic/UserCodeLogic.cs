using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities;
using JSCodingStudy.LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.CoreLogic
{
    public class UserCodeLogic<LessonType> : IUserCodeLogic<LessonType> where LessonType : ILesson
    {
        private IUserCodeDao<LessonType> dao;

        public UserCodeLogic(IUserCodeDao<LessonType> dao)
        {
            this.dao = dao;
        }

        public string Get(int user_id, int lesson_id)
        {
            return dao.GetById(user_id, lesson_id);
        }

        public bool Set(int user_id, int lesson_id, string code)
        {
            if(!dao.Add(user_id, lesson_id, code))
            {
                dao.Update(user_id, lesson_id, code);
            }
            return true;
        }
    }
}
