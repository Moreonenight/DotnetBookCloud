using DotnetBookCloud.DTO;
using DotnetBookCloud.Models;
using DotnetBookCloud.Services;
using DotnetBookCloud.Utils;
using DotnetBookCloud.Views;
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
    public class UserController: ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;

        public UserController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpGet("GetUserInfo")]
        public Object GetUserInfo()
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null) return new RetMessage(400, "Session已失效", null);
            AccountView accountView = new AccountView();
            accountView.setUser(user);
            return new RetMessage(200, "OK", accountView);
        }
    }
}
