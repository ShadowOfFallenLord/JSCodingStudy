using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities.Robot;
using JSCodingStudy.LogicInterfaces;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.CoreLogic.Robot
{
    public class RobotLessonLogic : ILessonLogic<LessonData>
    {
        private ILessonDao<LessonData> dao;

        public RobotLessonLogic(ILessonDao<LessonData> dao)
        {
            this.dao = dao;
        }

        public bool Add(LessonData lesson)
        {
            return dao.Add(lesson);
        }

        public IEnumerable<LessonData> GetAll()
        {
            return dao.GetAll();
        }

        public IEnumerable<LessonData> GetAvailable(User user)
        {
            return dao.GetAll().Where(x => x.Id <= user.LastLessons.Robot);
        }

        public LessonData GetById(int id)
        {
            return dao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return dao.RemoveById(id);
        }

        public bool Update(LessonData lesson)
        {
            return dao.Update(lesson);
        }
    }
}
