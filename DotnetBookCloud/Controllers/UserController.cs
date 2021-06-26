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
using BookCloudCLRLogger;

namespace DotnetBookCloud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;
        static private BookCloudLogger logger = new BookCloudLogger();

        public UserController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpGet("GetUserInfo")]
        public Object GetUserInfo()
        {
            User user = RedisUtils.GetUser(Request, _context.Users, _redis);
            if (user == null)
            {
                string s = "GetUserInfo::Session is invalid.";
                logger.Logger(ref s);
                return new RetMessage(400, "Session已失效", null);
            }
            AccountView accountView = new AccountView();
            accountView.setUser(user);
            string s_s = "GetUserInfo::user " + user.UserId + " get info success.";
            logger.Logger(ref s_s);
            return new RetMessage(200, "OK", accountView);
        }
    }
}
