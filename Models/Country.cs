using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cadl.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string ISO { get; set; }
        public string Name { get; set; }
        public string NiceName { get; set; }
        public string ISO3 { get; set; }
        public Int16 NumCode { get; set; }
        public int PhoneCode { get; set; }
    }
}
