using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.DTO
{
    public class UserDTO
    {
        [DisplayName("ID")]
        public string Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }
        [DisplayName("Имя пользователя")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}