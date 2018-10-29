using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;
using System.Web.Mvc;
using BLL.Interfaces;
using AutoMapper;
using BLL.Infrastructure;
using PL.Models;

namespace Final_Project.Controllers
{
    public class UserController : Controller
    {
        IUserService UserService;
        public UserController(IUserService userserv)
        {
            UserService = userserv;
        }
        // GET: User
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                IEnumerable<UserDTO> userDTO = UserService.GetUsers();
                return View(userDTO);
            }
            else return RedirectToAction("Index", "UserTests");
        }
        public ActionResult Delete(string id)

        {
            if (id == null)
            {
                throw new ValidationException("Ид пользователя не найдено", "");
            }
            var User=UserService.GetUser(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            UserViewModel userView = mapper.Map<UserDTO, UserViewModel>(User);
            if (userView == null)
            {
                return HttpNotFound();
            }

            return View(userView);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}