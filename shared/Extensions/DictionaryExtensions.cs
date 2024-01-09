using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCodeShared.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Create a new entry in the dictionary with the given key,val,
        /// or if the key already exists, sum up the values.
        /// </summary>
        public static void AddAggregate<K>(this Dictionary<K, int> dict, K key, int item)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = dict[key] + item;
            }
            else
            {
                dict.Add(key, item);
            }
        }

        public static void AddAggregate(this Dictionary<int, int> dict, int key, int item)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = dict[key] + item;
            }
            else
            {
                dict.Add(key, item);
            }
        }
        public static void AddAggregate(this Dictionary<string, int> dict, string key, int item)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = dict[key] + item;
            }
            else
            {
                dict.Add(key, item);
            }
        }
        public static void AddAggregate(this Dictionary<Point, List<int>> dict, Point key, int item)
        {
            if (dict.ContainsKey(key))
            {
                dict[key].Add(item);
            }
            else
            {
                dict.Add(key, new List<int>() { item });
            }
        }
    }
}
