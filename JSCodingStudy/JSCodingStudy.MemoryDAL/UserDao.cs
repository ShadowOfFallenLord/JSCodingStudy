﻿using JSCodingStudy.DALInterfaces;
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
        public static User FullUser { get; } = new User()
        {
            Id = 1,
            Login = "userf",
            Password = "123",
            RobotLastLesson = Robot.RobotLessonDao.LessonsCount,
        };

        private List<User> users;

        public UserDao()
        {
            users = new List<User>();

            users.Add(FullUser);

            users.Add(new User
            {
                Id = 2,
                Login = "user1",
                Password = "123",
                RobotLastLesson = 1,
            });
        }

        public bool Add(User user)
        {
            if (users.Any(x => x.Login == user.Login))
            {
                return false;
            }

            user.Id = users.Count > 0 ? users.Last().Id + 1 : 1;
            user.RobotLastLesson = 1;
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

        public bool UpdateLessons(User user)
        {
            int index = users.FindIndex(x => x.Id == user.Id);

            if (index < 0)
            {
                return false;
            }

            users[index].RobotLastLesson = user.RobotLastLesson;
            return true;
        }
    }
}
