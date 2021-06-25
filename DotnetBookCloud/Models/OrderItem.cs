using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }
    }
}
