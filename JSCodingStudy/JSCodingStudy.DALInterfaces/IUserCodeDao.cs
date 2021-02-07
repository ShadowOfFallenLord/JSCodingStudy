using JSCodingStudy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.DALInterfaces
{
    public interface IUserCodeDao
    {
        bool Add(UserCode code);
        UserCode GetById(int user_id, int lesson_id);
        bool Update(UserCode code);
        bool RemoveById(int user_id, int lesson_id);
    }
}
