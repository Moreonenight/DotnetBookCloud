using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Models
{
    public class CartItem
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

    }
}
