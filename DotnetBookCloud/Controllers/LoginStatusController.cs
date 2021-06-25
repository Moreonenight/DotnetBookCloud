using App.Metrics.Concurrency;
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
    public class LoginStatusController : ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;

        public LoginStatusController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpPost("Register")]
        public Object Register([FromBody] RegisterDTO request)
        {
            AccountView AccountView = new();
            var users = _context.Users.Where(x => x.Name == request.Name);
            if (users.Any()) return new RetMessage(400, "用户名已存在", null);
            User user = new()
            {
                Name = request.Name
            };
            double seed = ThreadLocalRandom.NextDouble();
            user.Salt = HashHelper.ComputeSHA256Hash(request.Name + seed);
            user.Password = HashHelper.ComputeSHA256Hash(request.Password + user.Salt);
            user.Email = request.Email;
            _context.Users.Add(user);
            _context.SaveChanges();
            AccountView.setUser(user);
            return new RetMessage(200, "OK", AccountView);

        }

        [HttpPost("Login")]
        public Object Login([FromBody] LoginDTO request)
        {
            AccountView AccountView = new();
            String sessionId = RedisUtils.CreateSessionId(request.Name, request.Password, _context.Users, _redis);
            if (sessionId == null) return new RetMessage(400, "用户不存在", null);
            var cookieOptions = new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                MaxAge = new TimeSpan(24, 0, 0)
            };
            Response.Cookies.Append("sessionId", sessionId, cookieOptions);
            User user = RedisUtils.GetUser(sessionId, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "用户不存在", null);
            AccountView.setUser(user);
            return new RetMessage(200, "OK", AccountView);
        }

        [HttpGet("LoginStatus")]
        public Object LoginStatus()
        {
            AccountView AccountView = new();
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "当前未登录", null);
            AccountView.setUser(user);

            return new RetMessage(200, "OK", AccountView);
        }

        [HttpPost("Logout")]
        public Object Logout()
        {
            bool hasSessionId = Request.Cookies.TryGetValue("sessionId", out string sessionId);
            if (!hasSessionId) return new RetMessage(400, "当前未登录", null);
            _redis.KeyDelete(sessionId);
            Response.Cookies.Delete("sessionId");
            return new RetMessage(200, "登出成功", null);
        }
    }
}
