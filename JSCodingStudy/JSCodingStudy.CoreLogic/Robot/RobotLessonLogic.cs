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
    public class RobotLessonLogic : ILessonLogic<RobotLessonData>
    {
        private ILessonDao<RobotLessonData> dao;

        public RobotLessonLogic(ILessonDao<RobotLessonData> dao)
        {
            this.dao = dao;
        }

        public bool Add(RobotLessonData lesson)
        {
            return dao.Add(lesson);
        }

        public IEnumerable<RobotLessonData> GetAll()
        {
            return dao.GetAll();
        }

        public IEnumerable<RobotLessonData> GetAvailable(User user)
        {
            return dao.GetAll().Where(x => x.Id <= user.LastLessons.Robot);
        }

        public RobotLessonData GetById(int id)
        {
            return dao.GetById(id);
        }

        public bool RemoveById(int id)
        {
            return dao.RemoveById(id);
        }

        public bool Update(RobotLessonData lesson)
        {
            return dao.Update(lesson);
        }
    }
}
