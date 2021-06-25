using DotnetBookCloud.DTO;
using DotnetBookCloud.Models;
using DotnetBookCloud.Services;
using DotnetBookCloud.Utils;
using DotnetBookCloud.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;

        public OrderController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpPost("AddOrder")]
        public Object AddOrder([FromBody] AddOrderDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            Models.Order order = new();
            order.Address = request.Address;
            order.Telephone = request.Telephone;
            order.ReceiverName = request.ReceiverName;
            order.UserId = user.UserId;
            order.CreateTime = DateTime.Now;
            order.TotalPrice = 0;
            order.Status = "待付款";
            order.PostCost = 10;
            _context.Orders.Add(order);
            _context.SaveChanges();
            foreach (var orderItem in request.OrderItems)
            {
                OrderItem new_orderItem = new()
                {
                    OrderId = order.OrderId,
                    BookId = orderItem.BookId,
                    Quantity = orderItem.Quantity
                };
                var book = _context.Books.Find(orderItem.BookId);
                new_orderItem.Price = book.Price;
                new_orderItem.Discount = book.Discount;
                order.TotalPrice += book.Price * book.Discount * orderItem.Quantity;
                _context.OrderItems.Add(new_orderItem);
            }
            _context.Orders.Update(order);
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }

        [HttpPost("GetOrderDetail")]
        public Object GetOrderDetail([FromBody] OrderIdDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            var order = _context.Orders.Find(request.OrderId);
            if (order == null)
            {
                return new RetMessage(400, "订单不存在", null);
            }
            var orderItems = _context.OrderItems.Where(o => o.OrderId == request.OrderId);
            OrderView orderView = new(order, orderItems);
            return new RetMessage(200, "OK", orderView);
        }

        [HttpGet("GetOrders")]
        public Object GetOrders()
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            var orders = _context.Orders.Where(b => b.UserId == user.UserId);
            return new RetMessage(200, "OK", orders);
        }

        [HttpPost("DelOrder")]
        public Object DelOrder([FromBody] OrderIdDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            Models.Order order = _context.Orders.Find(request.OrderId);
            if (order == null)
            {
                return new RetMessage(400, "订单已被删除", null);
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            var orderItems = _context.OrderItems.Where(o => o.OrderId == request.OrderId);
            foreach (var orderItem in orderItems)
            {
                _context.OrderItems.Remove(orderItem);
            }
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }

        [HttpPost("EditOrder")]
        public Object EditOrder([FromBody] EditOrderDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            Models.Order order = _context.Orders.Find(request.OrderId);
            if (order == null)
            {
                return new RetMessage(400, "订单不存在", null);
            }
            order.Address = request.Address;
            order.Telephone = request.Telephone;
            order.ReceiverName = request.ReceiverName;
            _context.Orders.Update(order);
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }
    }
}
