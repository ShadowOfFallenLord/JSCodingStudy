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
        private UsersDbContext context;

        public UserDao()
        {
            context = new UsersDbContext();
        }

        public bool Add(User user)
        {
            try
            {
                user.Id = context.Users_Add(user.Login, user.Password);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return context.Users_GetById(id).FirstOrDefault();
        }

        public User GetByLogin(string login)
        {
            return context.Users_GetByLogin(login).FirstOrDefault();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLessons(User user)
        {
            try
            {
                return context.Users_UpdateLessons(user.Id, user.RobotLastLesson) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
