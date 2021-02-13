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
        public RobotLessonDao()
        {
            lessons.Add(GenerateLesson1());
            lessons.Add(GenerateLesson2());
            lessons.Add(GenerateLesson3());
        }

        private RobotLessonData GenerateLesson1()
        {
            return new RobotLessonData
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
        }

        private RobotLessonData GenerateLesson2()
        {
            return new RobotLessonData
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
        }

        private RobotLessonData GenerateLesson3()
        {
            return new RobotLessonData
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
        }
    }
}
