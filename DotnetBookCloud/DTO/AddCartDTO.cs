using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.DTO
{
    public class AddCartDTO
    {
        public int BookId  { get; set; }
        public int Quantity { get; set; }
    }
}
