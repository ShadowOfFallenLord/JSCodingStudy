using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSCodingStudy.Areas.Robot.Model
{
    public class APIReference
    {
        public bool Move { get; set; }
        public bool Check { get; set; }
        public bool Draw { get; set; }
    }

    public class LessonInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class LessonData : LessonInfo
    {
        public string Task { get; set; }

        public string[] Pattern { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }

        public APIReference APIHelp { get; set; }

        public string Code { get; set; }
    }

    public class LessonsDaoMoq
    {
        private static List<LessonData> lessons;

        private static LessonData GenerateLesson1()
        {
            return new LessonData
            {
                Id = 1,

                Title = "Передвижение 1",

                Task = "Сперва попробуем двигаться по вертикали.\n" +
                    "Для передвижения используется команда Robot.Move с аргументом, обозначающим направление. Подробнее можно узнать нажав на кнопку Помощь.\n" +
                    "Нужно поднять 2 флага (F).\n" +
                    "Для этого нужно один раз передвинуть робота вверх и два раза вниз.",

                Pattern = new string[]
                {
                    ".....",
                    ".F...",
                    ".....",
                    ".F...",
                    ".....",
                },
                StartX = 1,
                StartY = 2,

                APIHelp = new APIReference
                {
                    Move = true,
                    Check = false,
                    Draw = false,
                },

                Code = "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Down);"
            };
        }

        private static LessonData GenerateLesson2()
        {
            return new LessonData
            {
                Id = 2,

                Title = "Передвижение 1",

                Task = "Теперь попробуем двигаться по горизонтали.\n" +
                    "Для передвижения используется команда Robot.Move с аргументом, обозначающим направление. Подробнее можно узнать нажав на кнопку Помощь.\n" +
                    "Нужно поднять 2 флага (F).\n" +
                    "Для этого нужно один раз передвинуть робота влево и два раза вправо.",

                Pattern = new string[]
                {
                    ".....",
                    ".....",
                    ".F.F.",
                    ".....",
                    ".....",
                },
                StartX = 2,
                StartY = 2,

                APIHelp = new APIReference
                {
                    Move = true,
                    Check = false,
                    Draw = false,
                },

                Code = "Robot.Move(Directions.Left);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Right);"
            };
        }

        private static LessonData GenerateLesson3()
        {
            return new LessonData
            {
                Id = 3,

                Title = "Передвижение 3",

                Task = "Начнем с передвижения.\n" +
                    "Для этого используется команда Robot.Move с аргументом, обозначающим направление. Подробнее можно узнать нажав на кнопку Помощь.\n" +
                    "Нужно поднять 3 флага (F) и закончить в клетке финиша (*).\n" +
                    "Для этого нужно дважды передвинуть робота вверх, дважды вправо, дважды вниз и один раз вправо.",

                Pattern = new string[]
                {
                    ".....",
                    ".F.F.",
                    ".....",
                    "..*F.",
                    ".....",
                },
                StartX = 1,
                StartY = 3,

                APIHelp = new APIReference
                {
                    Move = true,
                    Check = false,
                    Draw = false,
                },

                Code = "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Up);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Right);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Down);\n" +
                "Robot.Move(Directions.Left);"
            };
        }

        static LessonsDaoMoq()
        {
            lessons = new List<LessonData>();
            lessons.Add(GenerateLesson1());
            lessons.Add(GenerateLesson2());
            lessons.Add(GenerateLesson3());
        }

        public static LessonData GetLessonById(int id) => lessons
            .FirstOrDefault(x => x.Id == id);

        public static IEnumerable<LessonData> GetAllLessons() => lessons;

        public static IEnumerable<LessonInfo> GetAllInfo() => lessons;
    }

    public static class UserCodeDaoMoq
    {
        public static Dictionary<int, Dictionary<int, string>> codes = new Dictionary<int, Dictionary<int, string>>();

        public static string Get(int user_id, int lesson_id)
        {
            string res = "";
            if(codes.ContainsKey(user_id))
            {
                if (codes[user_id].ContainsKey(lesson_id))
                {
                    res = codes[user_id][lesson_id];
                }
            }
            return res;
        }

        public static void Set(int user_id, int lesson_id, string code)
        {
            if (!codes.ContainsKey(user_id))
            {
                codes.Add(user_id, new Dictionary<int, string>());
            }
            if(!codes[user_id].ContainsKey(lesson_id))
            {
                codes[user_id].Add(lesson_id, null);
            }

            codes[user_id][lesson_id] = code;
        }
    }
}