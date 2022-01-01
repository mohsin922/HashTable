using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class MyMapNode<K, V>
    {
        public int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size) //constructor of class
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        //Get array position
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        //Create linkedlist for a particular position
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

        //Check if element is already Present
        public int CheckHash(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            int count = 1;
            bool found = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);

            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    count = Convert.ToInt32(keyValue.Value) + 1;
                    found = true;
                    founditem = keyValue;
                }
            }
            if (found)
            {
                LinkedListofPosition.Remove(founditem);
                return count;
            }
            else
            {
                return 1;
            }

        }

        //Display Linkedlist elements for particular key
        public void Display(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.Key.Equals(key))
                {
                    Console.WriteLine("Key: " + keyValue.Key + "\t Value: " + keyValue.Value);
                }

            }
        }

        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }

    }
}
