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
        bool Add(LessonType lesson);
        LessonType GetById(int id);
        IEnumerable<LessonType> GetAll();
        bool Update(LessonType lesson);
        bool RemoveById(int id);
    }
}
