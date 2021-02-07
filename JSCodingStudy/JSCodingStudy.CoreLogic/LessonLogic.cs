using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities;
using JSCodingStudy.LogicInterfaces;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.CoreLogic
{
    public class LessonLogic<LessonType> : ILessonLogic<LessonType> where LessonType : ILesson
    {
        private ILessonDao<LessonType> dao;
        private Func<User, int> last_lesson;

        public LessonLogic(ILessonDao<LessonType> dao, Func<User, int> last_lesson)
        {
            this.dao = dao;
            this.last_lesson = last_lesson;
        }

        public bool Add(LessonType lesson)
        {
            return dao.Add(lesson);
        }

        public IEnumerable<LessonType> GetAll()
        {
            return dao.GetAll().ToList();
        }

        public IEnumerable<LessonType> GetAvailable(User user)
        {
            return dao.GetAll()
                .Where(x => x.Id <= last_lesson(user))
                .ToList();
        }

        public LessonType GetById(int id)
        {
            return dao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return dao.RemoveById(id);
        }

        public bool Update(LessonType lesson)
        {
            return dao.Update(lesson);
        }
    }
}
