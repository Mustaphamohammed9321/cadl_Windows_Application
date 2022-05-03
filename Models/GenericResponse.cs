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


    public class CountryResponse
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    } 
    

    public class StateResponse
    {
        public int Id { get; set; }
        public string StateName { get; set; }
    }
     
    
    public class LGAResponse
    {
        public int LGAId { get; set; }
        public string LGAName { get; set; }
    }






}
