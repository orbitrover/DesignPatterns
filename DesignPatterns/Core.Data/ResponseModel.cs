using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class ResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseData { get; set; }
    }
}
