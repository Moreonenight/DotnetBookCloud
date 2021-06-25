using DotnetBookCloud.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Views
{
    public class OrderItemView
    {
        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
    public class OrderView
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public double PostCost { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string ReceiverName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ReceivedTime { get; set; }

        public Object OrderItems { get; set; }


        public OrderView(Order order, IQueryable<OrderItem> orderItems)
        {
            UserId = order.UserId;
            TotalPrice = order.TotalPrice;
            Status = order.Status;
            PostCost = order.PostCost;
            Address = order.Address;
            Telephone = order.Telephone;
            ReceiverName = order.ReceiverName;
            CreateTime = order.CreateTime;
            ReceivedTime = order.ReceivedTime;
            OrderItems = orderItems;
        }
    }
}
