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
    public class CartController : ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;

        public CartController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpPost("AddCart")]
        public Object AddCart([FromBody] AddCartDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            CartItem cartItem = new CartItem();
            cartItem.UserId = user.UserId;
            cartItem.BookId = request.BookId;
            cartItem.Quantity = request.Quantity;
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }

        [HttpGet("CheckCart")]
        public Object CheckCart()
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            var cartItemList = _context.CartItems.Where(c => c.UserId == user.UserId);
            return new RetMessage(200, "OK", cartItemList);
        }

        [HttpPost("DelCart")]
        public Object DelCart([FromBody] BookIdDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            CartItem cartItem = _context.CartItems.Find(user.UserId, request.BookId);
            if (cartItem == null)
            {
                return new RetMessage(400, "商品已被删除", null);
            }
            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }

        [HttpPost("EditCart")]
        public Object EditCart([FromBody] AddCartDTO request)
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            CartItem cartItem = _context.CartItems.Find(user.UserId, request.BookId);
            if (cartItem == null)
            {
                return new RetMessage(400, "商品已被删除", null);
            }
            cartItem.Quantity = request.Quantity;
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
            return new RetMessage(200, "OK", null);
        }
    }
}
