using System;
using System.Collections.Generic;

namespace ObjectMemoryCache
{
    public class MRUCache<TKey, TValue> : ICacheAlgorithm<TKey, TValue>
    {
        Dictionary<TKey, LinkedListNode<EntryNode<TKey, TValue>>> entries
                    = new Dictionary<TKey, LinkedListNode<EntryNode<TKey, TValue>>>();

        LinkedList<EntryNode<TKey, TValue>> entryList = new LinkedList<EntryNode<TKey, TValue>>();

        int maxEntries;

        public MRUCache(int maximumEntries = 1)
        {
            maxEntries = maximumEntries;
        }

        //public int MaximumEntries { get => maxEntries; set => maxEntries = value; }

        public void AddOrReplace(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("Parameter cannot be null", "key");
            if (value == null)
                throw new ArgumentNullException("Parameter cannot be null", "value");
            if (maxEntries <= 0)
                throw new Exception("Maximum Entries must be greater than zero");

            var node = new LinkedListNode<EntryNode<TKey, TValue>>(new EntryNode<TKey, TValue>
            {
                Key = key,
                Value = value
            });

            //checking if an entry is already present in the cache for the same key, and update the entry
            if (entries.ContainsKey(key))
                entryList.Remove(entries[key]); // O(1) operation as Remove(LinkedListNode<T>)
            else
                CheckCapacity(key);

            entryList.AddFirst(node);

            entries[key] = node;
        }

        public TValue Get(TKey key)
        {
            TValue value = default(TValue);

            if (key == null)
                return value;

            if (entries.TryGetValue(key, out var node))
            {
                MoveListEntryToFirst(node);
                value = node.Value.Value;
            }
            return value;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentException("Parameter cannot be null", "key");

            if (entries.TryGetValue(key, out var node))
            {
                entryList.Remove(node); // O(1) operation as Remove(LinkedListNode<T>)
                entries.Remove(key);
            }
        }

        private void MoveListEntryToFirst(LinkedListNode<EntryNode<TKey, TValue>> node)
        {
            entryList.Remove(node); // O(1) operation as Remove(LinkedListNode<T>)
            entryList.AddFirst(node);
        }

        private void CheckCapacity(TKey key)
        {
            if (entries.Count == maxEntries)
            {
                entries.Remove(entryList.First.Value.Key);
                entryList.RemoveFirst();
            }
        }

        public bool Contains(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
