using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.LogicInterfaces
{
    public interface IUserLogic
    {
        bool Add(User user);
        User GetById(int id);
        User GetByLogin(string login);
        bool Update(User user);
        bool RemoveById(int id);
    }
}
