using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Areas.Admin.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Cash { get; set; }
        public bool IsBlocked { get; set; }
    }
}