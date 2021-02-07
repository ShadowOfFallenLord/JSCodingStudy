using JSCodingStudy.LessonsEntities;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LogicInterfaces
{
    public interface IUserCodeLogic<LessonType> where LessonType : ILesson
    {
        bool Set(int user_id, int lesson_id, string code);
        string Get(int user_id, int lesson_id);
    }
}
