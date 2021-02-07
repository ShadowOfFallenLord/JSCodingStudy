using JSCodingStudy.DALInterfaces;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL
{
    public class UserDao : IUserDao
    {
        private List<User> users;

        public UserDao()
        {
            users = new List<User>();

            users.Add(new User
            {
                Id = 1,
                Login = "user1",
                Password = "123",
                LastLessons = new UserLastLessons()
            });
        }

        public bool Add(User user)
        {
            if (users.Any(x => x.Login == user.Login))
            {
                return false;
            }

            user.Id = users.Count > 0 ? users.Last().Id + 1 : 1;
            user.LastLessons = new UserLastLessons();
            users.Add(user);
            return true;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(x => x.Login == login);
        }

        public IEnumerable<User> GetAll()
        {
            return users.Select(x => x);
        }

        public bool RemoveById(int id)
        {
            User user = GetById(id);

            if (user is null)
            {
                return false;
            }

            return users.Remove(user);
        }

        public bool Update(User user)
        {
            int index = users.FindIndex(x => x.Id == user.Id);

            if (index < 0)
            {
                return false;
            }

            users[index] = user;
            return true;
        }
    }
}
