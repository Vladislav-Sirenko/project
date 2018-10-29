using DAL.EF;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Final_ProjectContext db;
        private EFGenericRepository<Test> TestRepository;
        private EFGenericRepository<Answer> AnswerRepository;
        private EFGenericRepository<Question> QuestionRepository;
        private EFGenericRepository<Result> ResultRepository;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public EFUnitOfWork()
        {
            db = new Final_ProjectContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }
        public IRepository<Test> Tests
        {
            get
            {
                if (TestRepository == null)
                    TestRepository = new EFGenericRepository<Test>(db);
                return TestRepository;
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (AnswerRepository == null)
                    AnswerRepository = new EFGenericRepository<Answer>(db);
                return AnswerRepository;
            }
        }
        public IRepository<Question> Questions
        {
            get
            {
                if (QuestionRepository == null)
                    QuestionRepository = new EFGenericRepository<Question>(db);
                return QuestionRepository;
            }
        }
   
        public IRepository<Result> Results
        {
            get
            {
                if (ResultRepository == null)
                    ResultRepository = new EFGenericRepository<Result>(db);
                return ResultRepository;
            }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }

      

       

    }
}