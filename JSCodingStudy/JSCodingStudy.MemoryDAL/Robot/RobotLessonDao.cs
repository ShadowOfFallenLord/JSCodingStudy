using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL.Robot
{
    public class RobotLessonDao : ILessonDao<RobotLessonData>
    {
        private List<RobotLessonData> lessons;

        public RobotLessonDao()
        {
            lessons = new List<RobotLessonData>();
        }

        public bool Add(RobotLessonData lesson)
        {
            lesson.Id = lessons.Count > 0 ? lessons.Last().Id + 1 : 1;
            lessons.Add(lesson);
            return true;
        }

        public IEnumerable<RobotLessonData> GetAll()
        {
            return lessons.Select(x => x);
        }

        public RobotLessonData GetById(int id)
        {
            return lessons.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveById(int id)
        {
            RobotLessonData lesson = GetById(id);

            if (lesson is null)
            {
                return false;
            }

            return lessons.Remove(lesson);
        }

        public bool Update(RobotLessonData lesson)
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
