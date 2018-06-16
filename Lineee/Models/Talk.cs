using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lineee.Models
{
    public class Talk
    {
        public int ID { get; set; }
        public int FromNameID { get; set; }
        public int ToNameID { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }

        public Talk() { }
    }
}
