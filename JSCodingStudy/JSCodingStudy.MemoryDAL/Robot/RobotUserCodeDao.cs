using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities.Robot;
using JSCodingStudy.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL.Robot
{
    public class RobotUserCodeDao : IUserCodeDao<LessonData>
    {
        private Dictionary<int, Dictionary<int, string>> codes;

        public RobotUserCodeDao()
        {
            codes = new Dictionary<int, Dictionary<int, string>>();
        }

        public bool Add(int user_id, int lesson_id, string code)
        {
            throw new NotImplementedException();
        }

        public string GetById(int user_id, int lesson_id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int user_id, int lesson_id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int user_id, int lesson_id, string code)
        {
            throw new NotImplementedException();
        }

        private string this[int user_id, int lesson_id]
        {
            get
            {
                if (!codes.ContainsKey(user_id))
                {
                    codes.Add(user_id, new Dictionary<int, string>());
                }

                if (codes[user_id].ContainsKey(lesson_id))
                {
                    return codes[user_id][lesson_id];
                }

                return "";
            }
            set
            {
                if (!codes.ContainsKey(user_id))
                {
                    codes.Add(user_id, new Dictionary<int, string>());
                }

                if (!codes[user_id].ContainsKey(lesson_id))
                {
                    codes[user_id].Add(lesson_id, null);
                }

                codes[user_id][lesson_id] = value;
            }
        }

        private bool CheckHas(int user_id, int lesson_id)
        {
            if (!codes.ContainsKey(user_id))
            {
                return false;
            }

            if (!codes[user_id].ContainsKey(lesson_id))
            {
                return false;
            }

            return true;
        }
    }
}
