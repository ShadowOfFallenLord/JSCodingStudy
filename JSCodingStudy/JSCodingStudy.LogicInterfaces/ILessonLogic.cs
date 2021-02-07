using JSCodingStudy.LessonsEntities;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LogicInterfaces
{
    public interface ILessonLogic<LessonType> where LessonType : ILesson
    {
        bool Add(LessonType lesson);
        LessonType GetById(int id);
        IEnumerable<LessonType> GetAll();
        IEnumerable<LessonType> GetAvailable(User user);
        bool Update(LessonType lesson);
        bool RemoveById(int id);
    }
}
