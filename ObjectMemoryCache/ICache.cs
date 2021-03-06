﻿namespace ObjectMemoryCache
{
    public interface ICache<TKey, TValue>
    {
        /// <summary>
        /// Insert or replace an entry to the cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddOrReplace(TKey key, TValue value);

        /// <summary>
        /// Returns an entry from the cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue Get(TKey key);

        /// <summary>
        /// Determines whether an entry exists in the cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(TKey key);

        /// <summary>
        /// Get the number of entries in the cache
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Clear the Cache
        /// </summary>
        void Clear();

        /// <summary>
        /// Removes an entry from the cache
        /// </summary>
        /// <param name="key"></param>
        void Remove(TKey key);
    }
}
