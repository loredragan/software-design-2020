using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    [Serializable]
    public class Message
    {
        public string Content { get; set; }
        public IDictionary<string, string> ValuePairs { get; set; }
        public int UserId { get; set; }
        public string RequestType { get; set; }
        public object ResultData { get; set; }
        public Exception Exception { get; set; }
        
    }
}
