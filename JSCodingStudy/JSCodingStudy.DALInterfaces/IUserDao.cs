using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.DALInterfaces
{
    public interface IUserDao
    {
        bool Add(User user);
        User GetById(int id);
        User GetByLogin(string login);
        IEnumerable<User> GetAll();
        bool UpdateLessons(User user);
        bool RemoveById(int id);
    }
}
