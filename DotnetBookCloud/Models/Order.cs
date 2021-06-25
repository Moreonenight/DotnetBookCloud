using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public double PostCost { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string ReceiverName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReceivedTime { get; set; }

        [ForeignKey("OrderId")]
        public List<OrderItem> OrderItems { get; set; }
    }
}
