using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using CRUD_WEB_API_SP_MVC.Models;

namespace CRUD_WEB_API_SP_MVC.Models
{
    public class LoginViewModel
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}