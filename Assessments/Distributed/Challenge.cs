using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Distributed
{
    public class StringMap<TValue> : IStringMap<TValue> where TValue: class
    {
        private static readonly Dictionary<string, TValue> Map = new Dictionary<string, TValue>();
        public int Count { get; private set; }
        public TValue DefaultValue { get; set; }

        public bool AddElement(string key, TValue value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "Value cannot be null");
            if(key is null)
                throw new ArgumentNullException(nameof(key), "Key cannot be null");
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be empty string");
            
            if (Map.ContainsKey(key))
            {
                Map[key] = value;
                return true;
            }
            Map.Add(key, value);
            Count++;
            return false;
        }

        public bool RemoveElement(string key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key), "Key cannot be null");
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be empty string");
            var deleted = Map.Remove(key);
            if (deleted) Count--;
            return deleted;
        }

        public TValue GetValue(string key)
        {
            if (key is null)
                throw new ArgumentNullException(nameof(key), "Key cannot be null");
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be empty string");
            return Map.ContainsKey(key) ? Map[key] : DefaultValue;
        }
    }
}
