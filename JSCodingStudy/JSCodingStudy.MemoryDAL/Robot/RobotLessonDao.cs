using JSCodingStudy.DALInterfaces;
using JSCodingStudy.LessonsEntities.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.MemoryDAL.Robot
{
    public class RobotLessonDao : LessonDao<RobotLessonData>
    {
        public static int LessonsCount => GenerateLessons().Count();

        public RobotLessonDao()
        {
            lessons.AddRange(GenerateLessons());
        }

        private static IEnumerable<RobotLessonData> GenerateLessons()
        {
            // Lesson 1 - Передвижение 1
            yield return new RobotLessonData
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

                HelpAPIMove = true,
                HelpAPICheck = false,
                HelpAPIDraw = false,
            };

            // Lesson 2 - Передвижение 2
            yield return new RobotLessonData
            {
                Id = 2,

                Title = "Передвижение 2",

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

                HelpAPIMove = true,
                HelpAPICheck = false,
                HelpAPIDraw = false,
            };

            // Lesson 3 - Передвижение 3
            yield return new RobotLessonData
            {
                Id = 3,

                Title = "Передвижение 3",

                Task = "Теперь соберем оба передвижения вместе.\n" +
                        "Нужно поднять 3 флага (F) и закончить в клетке финиша (*).\n" +
                        "Подробное описание команды перемещения можно узнать нажав на кнопку Помощь.\n" +
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

                HelpAPIMove = true,
                HelpAPICheck = false,
                HelpAPIDraw = false,
            };

            // Lesson 4 - Цикл for 1
            yield return new RobotLessonData
            {
                Id = 4,

                Title = "Цикл for 1",

                Task = "Если нужно выполнить некоторый набор операций определенное количество раз, можно использовать цикл for со следующим синтаксисом:\n" +
                           "for(<объявление счетчика>; <условие прекращение цикла>; <изменение счетчика>)\n" +
                           "{ <набор операций> }\n" +
                           "Например следующий код 5 раз передвинет Робота вверх:\n" +
                           "for(var i = 1; i <= 5; i++)\n" +
                           "{ Robot.Move(Directions.Up); }\n" +
                           "Здесь:\n" +
                           "-- var i = 1 - обявление счетчика i с начальным зачением 1,\n" +
                           "-- i <= 5 - условие продолжения цикла - пока i меньше или равно 5,\n" +
                           "-- i++ - увеличение счетчика i на 1.\n" +
                           "Нужно провести робота по границе доступной области с шириной 10 и высотой 5.",

                Pattern = new string[]
                {
                "*........F",
                "..........",
                "..........",
                "..........",
                "F........F",
                },
                StartX = 0,
                StartY = 0,

                HelpAPIMove = true,
                HelpAPICheck = false,
                HelpAPIDraw = false,
            };

            // Lesson 5 - Цикл for 2
            yield return new RobotLessonData
            {
                Id = 5,

                Title = "Цикл for 2",

                Task = "Нужно провести робота по спирали доступной области с шириной 10 и высотой 5.",

                Pattern = new string[]
                {
                    ".........F",
                    ".F......F.",
                    "..F*......",
                    "..F.....F.",
                    ".F.......F",
                },
                StartX = 0,
                StartY = 0,

                HelpAPIMove = true,
                HelpAPICheck = false,
                HelpAPIDraw = false,
            };
        }
    }
}
