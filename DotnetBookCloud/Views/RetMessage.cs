using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Views
{
    public class RetMessage
    {
        public int status { get; set; }

        public string message { get; set; }

        public object data { get; set; }

        public RetMessage(int status, string message, object data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}
