using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(PL.App_Start.Startup))]
namespace PL.App_Start
{
    public class Startup
    {
        /* IUserService UserService;
         public static IContainer IoC { get; set; }

         public Startup(IUserService UserServ)
         {
             UserService = UserServ;
         }

         public void Configuration(IAppBuilder app)
         {
             app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
             app.UseCookieAuthentication(new CookieAuthenticationOptions
             {
                 AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                 LoginPath = new PathString("/Account/Login"),
             });
         }*/
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService();
        }


    }
}
