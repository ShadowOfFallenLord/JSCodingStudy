using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL
{
    public class LessonDao<LessonType> : ILessonDao<LessonType> where LessonType : class, ILesson
    {
        protected List<LessonType> lessons;

        public LessonDao()
        {
            lessons = new List<LessonType>();
        }

        public bool Add(LessonType lesson)
        {
            lesson.Id = lessons.Count > 0 ? lessons.Last().Id + 1 : 1;
            lessons.Add(lesson);
            return true;
        }

        public IEnumerable<LessonType> GetAll()
        {
            return lessons.Select(x => x);
        }

        public LessonType GetById(int id)
        {
            return lessons.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveById(int id)
        {
            LessonType lesson = GetById(id);

            if (lesson is null)
            {
                return false;
            }

            return lessons.Remove(lesson);
        }

        public bool Update(LessonType lesson)
        {
            int index = lessons.FindIndex(x => x.Id == lesson.Id);

            if (index < 0)
            {
                return false;
            }

            lessons[index] = lesson;
            return true;
        }
    }
}
