using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Views.HelperClasses
{
    public static class RequestBuilder
    {
        public static IDictionary<string, string> BuildFindRequest(IDictionary<string, string> valuePairs)
        {
            const string _defaultValue = "all";
            var newDict = new Dictionary<string, string>();
            foreach (var key in valuePairs.Keys)
            {
                if (string.IsNullOrWhiteSpace(valuePairs[key]))
                {
                    var kvp = new KeyValuePair<string, string>(key, _defaultValue);
                    newDict.Add(kvp.Key, kvp.Value);
                }
                else
                {
                    newDict.Add(key, valuePairs[key]);
                }
            }

            return newDict; 
        }
    }
}
