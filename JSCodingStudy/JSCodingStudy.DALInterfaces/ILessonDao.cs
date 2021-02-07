using JSCodingStudy.LessonsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.DALInterfaces
{
    public interface ILessonDao<LessonType> where LessonType : ILesson
    {
        bool Add(LessonType user);
        LessonType GetById(int id);
        IEnumerable<LessonType> GetAll();
        bool Update(LessonType user);
        bool RemoveById(int id);
    }
}
