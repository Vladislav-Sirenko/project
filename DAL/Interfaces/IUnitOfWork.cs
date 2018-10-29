using DAL.Entities;
using DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
  public interface IUnitOfWork : IDisposable
    {
        IRepository<Test> Tests { get; }
        IRepository<Answer> Answers { get; }
        IRepository<Question> Questions { get; }
        IRepository<Result> Results { get; }
       
        void Save();

        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
