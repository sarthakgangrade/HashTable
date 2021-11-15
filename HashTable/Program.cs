using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!WELCOME TO HASHTABLE");
            Console.WriteLine("Hash table demo"); //() []
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To be or not to be");
            hash.frequencyOfWords("0");
        }
    }

    internal class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);  // |-5| =5 |3|=3 |-3|=3
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
#pragma warning disable IDE1006 // Naming Styles
        public void frequencyOfWords(K key)
#pragma warning restore IDE1006 // Naming Styles
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    foundItem = item;
                    string str = foundItem.Value.ToString();
                    Console.WriteLine("found data = " + str);
                    string[] arr = str.Split(',');
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (dict.ContainsKey(arr[i]))
                        {
                            dict[arr[i]] = dict[arr[i]] + 1;
                        }
                        else
                        {
                            dict.Add(arr[i], 1);
                        }
                    }
                    foreach (KeyValuePair<String, int> entry in dict)
                    {
                        Console.WriteLine(entry.Key + " - " +
                                          entry.Value);
                        Console.ReadLine();
                    }
                }
            }
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        protected int GetArrayPosition(K key)
        {
            //Console.WriteLine("position given by gethashcode method " + key.GetHashCode());

            int position = key.GetHashCode() % size;
            //  Console.WriteLine("position given by gethashcode method "+position);
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }


    }

    public class KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }

    }
}
    

   