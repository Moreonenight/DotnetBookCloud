using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Models
{
    public class User
    {
            [Key]
            public int UserId { get; set; }

            public string Salt { get; set; }

            public string Name { get; set; }

            public string Password { get; set; }

            public string Email { get; set; }

            [ForeignKey("UserId")]
            public List<CartItem> CartItems { get; set; }

            [ForeignKey("UserId")]
            public List<Order> Orders { get; set; }
    }
}
