using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSkills.NetCore
{
    public interface IMultiDictionary<TKey, TValue>
    {

        IEnumerable<TValue> this[TKey key] { get; set; }

        IEnumerable<TKey> Keys { get; }

        IEnumerable<TValue> Values { get; }

        int Count { get; }

        void AddOrUpdate(TKey key, TValue value);

        bool ContainsKey(TKey key);

        // remove a key along with its values
        bool RemoveKey(TKey key);

        // remove a single value from a key values.
        bool RemoveValue(TKey key, TValue value);

        //Clear All Key values, but keep the key
        void Clear(TKey key);

        bool TryGetValue(TKey key, out IEnumerable<TValue> value);
    }
    public class MultiMap<TKey, TValue> : IMultiDictionary<TKey, TValue>, IEnumerable
    {
        private readonly Dictionary<TKey, IEnumerable<TValue>> _Data = new Dictionary<TKey, IEnumerable<TValue>>();

        public IEnumerable<TValue> Values => _Data.Values.SelectMany(x => x);

        public IEnumerable<TKey> Keys => _Data.Keys;

        public int Count => _Data.Count;

        public IEnumerable<TValue> this[TKey key]
        {
            get => _Data[key];
            set => AddOrUpdate(key, value);
        }

        public void AddOrUpdate(TKey key, IEnumerable<TValue> values)
        {
            if (ContainsKey(key)) // if key exists
            {
                (_Data[key] as List<TValue>)?.AddRange(values);
            }
            else
            {
                // add the new key with its value.
                _Data.Add(key, values);
            }
        }

        public void AddOrUpdate(TKey key, TValue value)
        {
            if (ContainsKey(key)) // if key exists
            {
                //check value and add it if not exists
                if (!_Data[key].Contains(value)) { (_Data[key] as List<TValue>)?.Add(value); }
            }
            else
            {
                // add the new key with its value.
                _Data.Add(key, new List<TValue>() { value });
            }
        }

        public void Clear(TKey key)
        {
            if (ContainsKey(key))
            {
                (_Data[key] as List<TValue>)?.Clear();
            }
        }

        public bool TryGetValue(TKey key, out IEnumerable<TValue> values) => _Data.TryGetValue(key, out values);

        public bool ContainsKey(TKey key) => _Data.ContainsKey(key);

        public bool RemoveKey(TKey key) => _Data.Remove(key);

        public bool RemoveValue(TKey key, TValue value) => ContainsKey(key) && (_Data[key] as List<TValue>)?.Remove(value) == true;

        public void Clean()
        {
            foreach (var item in _Data.Where(x => !x.Value.Any()))
            {
                _Data.Remove(item.Key);
            }
        }
        // enabling foreach loop
        public IEnumerator GetEnumerator() => _Data.GetEnumerator();
    }

    public static class DictionaryImplement
    {
        public static void DictionaryMap()
        {
            //Multi Map Implmentation
            // Create first MultiMap.
            var multiMap = new MultiMap<string, bool>();
            multiMap.AddOrUpdate("key1", true);
            multiMap.AddOrUpdate("key1", false);
            multiMap.AddOrUpdate("key2", false);

            foreach (string key in multiMap.Keys)
            {
                foreach (bool value in multiMap[key])
                {
                    Console.WriteLine("MULTIMAP: " + key + "=" + value);
                }
            }

            // Create second MultiMap.
            var multiMap2 = new MultiMap<string, string>();
            multiMap2.AddOrUpdate("animal", "cat");
            multiMap2.AddOrUpdate("animal", "dog");
            multiMap2.AddOrUpdate("human", "tom");
            multiMap2.AddOrUpdate("human", "tim");
            multiMap2.AddOrUpdate("mineral", "calcium");

            foreach (string key in multiMap2.Keys)
            {
                foreach (string value in multiMap2[key])
                {
                    Console.WriteLine("MULTIMAP2: " + key + "=" + value);
                }
            }
        }

        public static void DictionaryFind()
        {

            int N = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> phoneBook = new Dictionary<string, int>(N);
            for (int i = 0; i < N; i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                if (temp[1].Length == 8)
                {
                    phoneBook.Add(temp[0], Convert.ToInt32(temp[1]));
                }
            }
            string nameToSearch = "";
            while ((nameToSearch = Console.ReadLine()) != null)
            {
                int flagFound = 0;
                if (nameToSearch != "")
                {
                    if (phoneBook.ContainsKey(nameToSearch))
                    {
                        flagFound = 1;
                    }
                }
                if (flagFound == 1)
                {
                    Console.WriteLine(nameToSearch + "=" + phoneBook[nameToSearch]);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }

        }
    }


}
