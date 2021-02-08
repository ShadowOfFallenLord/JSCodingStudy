using JSCodingStudy.LessonsEntities;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.DALInterfaces
{
    public interface IUserCodeDao<LessonType> where LessonType : ILesson
    {
        bool Add(int user_id, int lesson_id, string code);
        string GetById(int user_id, int lesson_id);
        bool Update(int user_id, int lesson_id, string code);
    }
}
