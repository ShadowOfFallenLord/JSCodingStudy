using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LogicInterfaces;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.CoreLogic
{
    public class UserLogic : IUserLogic
    {
        private IUserDao dao;

        public UserLogic(IUserDao dao)
        {
            this.dao = dao;
        }

        public bool Add(User user)
        {
            return dao.Add(user);
        }

        public User GetById(int id)
        {
            return dao.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return dao.GetByLogin(login);
        }

        public IEnumerable<User> GetAll()
        {
            return dao.GetAll().ToList();
        }

        public bool RemoveById(int id)
        {
            return dao.RemoveById(id);
        }

        public bool UpdateLessons(User user)
        {
            return dao.UpdateLessons(user);
        }
    }
}
