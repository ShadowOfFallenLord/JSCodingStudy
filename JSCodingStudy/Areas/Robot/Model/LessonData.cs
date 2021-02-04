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
                Id = 0,

                Title = "Передвижение",

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
        }

        public static LessonData GetLessonById(int id) => lessons
            .FirstOrDefault(x => x.Id == id);

        public static IEnumerable<LessonData> GetAllLessons() => lessons;

        public static IEnumerable<LessonInfo> GetAllInfo() => lessons;
    }
}