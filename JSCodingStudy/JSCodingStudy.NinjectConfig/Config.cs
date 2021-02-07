using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSCodingStudy;
using JSCodingStudy.LessonsEntities.Robot;
using JSCodingStudy.UserEntities;

namespace JSCodingStudy.NinjectConfig
{
    public static class Config
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            BindUsers(kernel);
            BindLessons(kernel);
            BindUserCodes(kernel);
        }

        private static void BindUsers(IKernel kernel)
        {
            kernel
                .Bind<DALInterfaces.IUserDao>()
                .To<MemoryDAL.UserDao>()
                .InSingletonScope();

            kernel
                .Bind<LogicInterfaces.IUserLogic>()
                .To<CoreLogic.UserLogic>()
                .InSingletonScope();
        }

        private static void BindLessons(IKernel kernel)
        {
            kernel
                .Bind<DALInterfaces.ILessonDao<RobotLessonData>>()
                .To<MemoryDAL.Robot.RobotLessonDao>()
                .InSingletonScope();

            kernel
                .Bind<LogicInterfaces.ILessonLogic<RobotLessonData>>()
                .To<CoreLogic.LessonLogic<RobotLessonData>>()
                .InSingletonScope()
                .WithConstructorArgument("last_lesson", (Func<User, int>)(x => x.LastLessons.Robot));
        }

        private static void BindUserCodes(IKernel kernel)
        {
            kernel
                .Bind<DALInterfaces.IUserCodeDao<RobotLessonData>>()
                .To<MemoryDAL.Robot.RobotUserCodeDao>()
                .InSingletonScope();

            kernel
                .Bind<LogicInterfaces.IUserCodeLogic<RobotLessonData>>()
                .To<CoreLogic.UserCodeLogic<RobotLessonData>>()
                .InSingletonScope();
        }
    }
}
