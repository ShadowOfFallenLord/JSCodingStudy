using JSCodingStudy.DALInterfaces;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.EFSqlDAL
{
    public class UserDao : IUserDao
    {
        public bool Add(User user)
        {
            throw new NotImplementedException(); 
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLessons(User user)
        {
            throw new NotImplementedException();
        }
    }
}
