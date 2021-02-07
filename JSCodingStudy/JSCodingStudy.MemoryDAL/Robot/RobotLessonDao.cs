using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL.Robot
{
    public class RobotLessonDao : ILessonDao<LessonData>
    {
        private List<LessonData> lessons;

        public RobotLessonDao()
        {
            lessons = new List<LessonData>();
        }

        public bool Add(LessonData lesson)
        {
            lesson.Id = lessons.Count > 0 ? lessons.Last().Id + 1 : 1;
            lessons.Add(lesson);
            return true;
        }

        public IEnumerable<LessonData> GetAll()
        {
            return lessons.Select(x => x);
        }

        public LessonData GetById(int id)
        {
            return lessons.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveById(int id)
        {
            LessonData lesson = GetById(id);

            if (lesson is null)
            {
                return false;
            }

            return lessons.Remove(lesson);
        }

        public bool Update(LessonData lesson)
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
