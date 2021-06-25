using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string Abstract { get; set; }

        public int Inventory { get; set; }

        public bool Secondhand { get; set; }

        [ForeignKey("BookId")]
        public List<CartItem> CartItems { get; set; }

        [ForeignKey("BookId")]
        public List<OrderItem> OrderItems { get; set; }
    }
}
