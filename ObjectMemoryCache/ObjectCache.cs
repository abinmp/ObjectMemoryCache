

using System;

namespace ObjectMemoryCache
{
    public class ObjectCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly ICacheAlgorithm<TKey, TValue> algorithm;

        public ObjectCache(ICacheAlgorithm<TKey, TValue> cacheAlgorithm)
        {
            algorithm = cacheAlgorithm;
        }

        public void AddOrReplace(TKey key, TValue value)
        {
            algorithm.AddOrReplace(key, value);
        }

        public TValue Get(TKey key)
        {
            return algorithm.Get(key); 
        }

        public void Remove(TKey key)
        {
            algorithm.Remove(key);
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
