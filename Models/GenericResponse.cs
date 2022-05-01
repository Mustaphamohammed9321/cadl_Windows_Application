using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadl.Models
{
    public class GenericResponse
    {
        public object Data { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
