using System.Collections.Generic;

namespace System.Collections.Specialized
{
    public static class Extensions
    {
        public static string ToQueryString(this NameValueCollection collection)
        {
            List<string> parameters = new List<string>();

            foreach (string key in collection.AllKeys)
                parameters.Add(String.Concat(key, "=", Uri.EscapeDataString(collection[key])));

            return String.Concat("?", String.Join("&", parameters.ToArray()));
        }
    }
}
