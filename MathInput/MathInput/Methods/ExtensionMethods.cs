using System.Collections.Generic;

namespace MathInput.Methods
{
    public static class ExtensionMethods
    {
        public static void AdvancedAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue Value)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, Value);
            }
        }        
    }
}
