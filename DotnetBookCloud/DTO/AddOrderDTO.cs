using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.DTO
{
    public class AddOrderDTO
    {
        public string Address { get; set; }

        public string Telephone { get; set; }

        public string ReceiverName { get; set; }

        public AddOrderItemDTO[] OrderItems { get; set; }
    }
}
