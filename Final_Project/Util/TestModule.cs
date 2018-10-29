using BLL;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Util
{
    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestForming>().To<TestForming>();
            Bind<ITestChecking>().To<TestChecking>();
            Bind<ITestService>().To<TestService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IResultService>().To<ResultService>();
            Bind<IUserService>().To<UserService>();
            Bind<IServiceCreator>().To<ServiceCreator>();
            
        }
    }
}