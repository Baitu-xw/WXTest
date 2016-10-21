using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WXPay
{
    public class SortedDictionary:System.Collections.Generic.SortedDictionary<string,string>
    {
        public SortedDictionary(string key, string value)
        {
            keyValuePair.Key = key;
            keyValuePair.Value = value;
        }

        public KeyValuePair keyValuePair;
        
        internal void Add(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        internal bool ContainsKey(string name)
        {
            throw new NotImplementedException();
        }
    }
}
