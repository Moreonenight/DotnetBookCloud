using DotnetBookCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Views
{
    public class AccountView
    {
        public int UserId { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public void setUser(User user)
        {
            UserId = user.UserId;
            Email = user.Email;
            Name = user.Name;
        }
    }
}
