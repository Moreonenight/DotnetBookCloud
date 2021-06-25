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
    public class BookController : ControllerBase
    {
        private readonly BookCloudDBContext _context;
        private readonly IDatabase _redis;

        public BookController(BookCloudDBContext context, RedisService client)
        {
            _context = context;
            _redis = client.GetDatabase();
        }

        [HttpGet("SearchBook")]
        public Object SearchBook([FromBody] BookNameDTO request)
        {
            var books = _context.Books.Where(b => b.Name.Contains(request.Name));
            return new RetMessage(200, "OK", books);
        }

        [HttpGet("GetBookDetail")]
        public Object GetBookDetail([FromBody] BookIdDTO request)
        {
            var book = _context.Books.Find(request.BookId);
            if(book == null) return new RetMessage(400, "书本不存在", null);
            return new RetMessage(200, "OK", book);
        }

        [HttpGet("GetAllBook")]
        public Object GetAllBook()
        {
            var books = _context.Books.Where(b => true);
            return new RetMessage(200, "OK", books);
        }
    }
}
