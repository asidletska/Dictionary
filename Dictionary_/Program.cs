using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dictionary_
{
    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private List<TKey> _keys;
        private List<TValue> _values;

        public MyDictionary()
        {
            _keys = new List<TKey>();
            _values = new List<TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            if (_keys.Contains(key))
            {
                throw new ArgumentException("This word exists in the dictionary");
            }
            _keys.Add(key);
            _values.Add(value);
        }
        public TValue this[TKey key]
        {
            get
            {
                int index = _keys.IndexOf(key);
                if (index == -1)
                {
                    throw new KeyNotFoundException("This word is not in the dictionary");
                }
                return _values[index];
            }
        }
        public int Count => _keys.Count;
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            MyDictionary<string, string> myDictionary = new MyDictionary<string, string>
            {
                { "Apple",  "яблуко" },
                { "Sun",    "сонце" },
                { "House",  "дім" },
                { "Love",   "кохання" },
                { "Family", "сім'я" }
            };

            Console.WriteLine("Number of words in the dictionary: " + myDictionary.Count);

            Console.WriteLine("Dictionary content: ");
            foreach (var kvp in myDictionary)
            {
                Console.WriteLine($"Word: {kvp.Key},    Translate: {kvp.Value}");
            }
        }
    }
}
