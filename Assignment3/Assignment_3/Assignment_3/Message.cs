using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_3.Models;

namespace Assignment_3
{
    [Serializable]
    public class Message
    {
        public string Content { get; set; }
        public IDictionary<string, string> ValuePairs{ get; set; }
        public int UserId { get; set; }
        public string RequestType { get; set; }
        //public IEnumerable<IModel> ResultData { get; set; }
        public object ResultData { get; set; }
    }
}
