using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.DTO
{
    public class EditOrderDTO
    {
        public int OrderId { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string ReceiverName { get; set; }
    }
}
