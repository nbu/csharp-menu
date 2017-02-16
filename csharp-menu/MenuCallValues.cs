using System;
using System.Collections.Generic;

namespace CSharp.Console.Menu
{
    public class MenuCallValues
    {
        private readonly IDictionary<string, object> _values;

        public MenuCallValues()
        {
            _values = new Dictionary<string, object>();
        }

        public void AddValue<T>(string parameterName, T value)
        {
            _values.Add(parameterName, value);
        }

        public T GetValue<T>(string parameterName, T def, Type type)
        {
            object val;
            if (!_values.TryGetValue(parameterName, out val)) return def;

            if (val != null && val.GetType() == type)
            {
                return (T) val;
            }

            return def;
        }
    }
}