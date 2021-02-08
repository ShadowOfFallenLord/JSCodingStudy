using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL
{
    public class UserCodeDao<LessonType> : IUserCodeDao<LessonType> where LessonType : ILesson
    {
        private Dictionary<int, Dictionary<int, string>> codes;

        public UserCodeDao()
        {
            codes = new Dictionary<int, Dictionary<int, string>>();
        }

        public bool Add(int user_id, int lesson_id, string code)
        {
            if (CheckHas(user_id, lesson_id))
            {
                return false;
            }

            this[user_id, lesson_id] = code;
            return true;
        }

        public string GetById(int user_id, int lesson_id)
        {
            return this[user_id, lesson_id];
        }

        public bool RemoveById(int user_id, int lesson_id)
        {
            if (CheckHas(user_id, lesson_id))
            {
                this[user_id, lesson_id] = "";
                return true;
            };
            return false;
        }

        public bool Update(int user_id, int lesson_id, string code)
        {
            if (CheckHas(user_id, lesson_id))
            {
                this[user_id, lesson_id] = code;
                return true;
            };
            return false;
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
