using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCodingStudy.Models
{
    public class AppUserData
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int LastRobotLesson { get; set; }
    }

    public class AppUserDaoMoq
    {
        private static List<AppUserData> users;

        static AppUserDaoMoq()
        {
            users = new List<AppUserData>();
            users.Add(new AppUserData
            {
                Id = 1,
                Login = "user1",
                Password = "123",
                LastRobotLesson = 1
            });
        }

        public static AppUserData GetById(int id) => users
            .FirstOrDefault(x => x.Id == id);

        public static AppUserData Find(string login, string password) => users
            .FirstOrDefault(x => x.Login == login && x.Password == password);

        public static AppUserData Find(string login) => users
            .FirstOrDefault(x => x.Login == login);

        public static bool HasCheck(string login) => !(Find(login) is null);

        public static IEnumerable<AppUserData> GetAll() => users;

        public static AppUserData Add(string login, string password)
        {
            AppUserData user = new AppUserData
            {
                Id = users.Last().Id + 1,
                Login = login,
                Password = password,
                LastRobotLesson = 1
            };
            users.Add(user);
            return user;
        }
    }
}