using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class UserViewModel
    {
        [DisplayName("ID")]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}