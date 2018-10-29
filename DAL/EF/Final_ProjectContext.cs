using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL.Entities;

namespace DAL.EF
{
    public class Final_ProjectContext : IdentityDbContext<ApplicationUser> { 
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public Final_ProjectContext() : base("name=Final_ProjectContext")
        {
        }

        public System.Data.Entity.DbSet<DAL.Entities.Test> Tests { get; set; }

        public System.Data.Entity.DbSet<DAL.Entities.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<DAL.Entities.Answer> Answers { get; set; }
        public System.Data.Entity.DbSet<DAL.Entities.Result> Results { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
