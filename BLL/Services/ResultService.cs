using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Services
{
    public class ResultService : IResultService
    {
        IUnitOfWork Database { get; set; }

        public ResultService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<ResultDTO> GetResults(string User_ID, int Test_ID)
        {

            IEnumerable<Result> results = Database.Results.Find(id => id.User_ID == User_ID && id.Test_ID == Test_ID);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Result, ResultDTO>()).CreateMapper();
            var resultDTO = mapper.Map<IEnumerable<Result>, IEnumerable<ResultDTO>>(results);
            return resultDTO;
        }
        public ResultDTO GetFullOpen(string User_ID, int Test_ID, DateTime date)
        {
            IEnumerable<Result> b = Database.Results.Find(id => id.User_ID == User_ID && id.Test_ID == Test_ID);
            Result result = b.Where(dat => dat.Date.ToString() == date.ToString()).First();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Result, ResultDTO>()).CreateMapper();
            var resultDTO = mapper.Map<Result, ResultDTO>(result);
            return resultDTO;
        }
        public void ChangeResult (string User_ID, int Test_ID, DateTime date)
        {
            
            IEnumerable<Result> b = Database.Results.Find(id => id.User_ID == User_ID && id.Test_ID == Test_ID);
            Result result = b.Where(dat => dat.Date.ToString() == date.ToString()).First();
            if (!result.IsFullOpenChecked)
            {
                result.Score = result.Score + 1;
                result.IsFullOpenChecked = true;
                Database.Results.Update(result);
            }
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}