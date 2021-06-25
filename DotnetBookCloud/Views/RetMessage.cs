using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBookCloud.Views
{
    public class RetMessage
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }

        public RetMessage(int status, string message, object data)
        {
            this.Status = status;
            if(status == 200)
            {
                this.Success = true;
            }
            else
            {
                this.Success = false;
            }
            this.Message = message;
            this.Data = data;
        }
    }
}
