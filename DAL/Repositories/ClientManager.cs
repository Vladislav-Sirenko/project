using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public Final_ProjectContext context { get; set; }
        public ClientManager(Final_ProjectContext db)
        {
            context = db;
        }

        public void Create(ClientProfile item)
        {
            context.ClientProfiles.Add(item);
            context.SaveChanges();
        }
        public void Delete(string id)
        {
            var User=context.ClientProfiles.Find(id);
            context.ClientProfiles.Remove(User);
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
   
}