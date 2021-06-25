using DotnetBookCloud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Views
{
    public class CartItemView
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

        public CartItemView(CartItem cartItem, string name, string image, double price)
        {
            UserId = cartItem.UserId;
            BookId = cartItem.BookId;
            Quantity = cartItem.Quantity;
            Name = name;
            Image = image;
            Price = price;
        }
    }
}
