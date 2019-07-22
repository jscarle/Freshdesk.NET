using System.Collections.Generic;

namespace Freshdesk
{
    public class CustomFields : VirtualDictionary<string, object>
    {
        public override object this[string key]
        {
            get => base[key]; set
            {
                if (value != null)
                    base[key] = value;
            }
        }

        public override void Add(KeyValuePair<string, object> item)
        {
            if (item.Value != null)
                base.Add(item);
        }

        public override void Add(string key, object value)
        {
            if (value != null)
                base.Add(key, value);
        }
    }
}
