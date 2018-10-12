using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectMemoryCache;

namespace UnitTestObjectMemoryCache
{
    [TestClass]
    public class UnitTestObjectCache
    {
        [TestMethod]
        public void Test_LRU()
        {

            var numEntry = 3;

            var cache = new ObjectCache<string, string>(new LRUCache<string, string>(numEntry));
          
            cache.AddOrReplace("key1", "value1");
            Assert.AreEqual(cache.Get("key1"), "value1");           

            cache.AddOrReplace("key1", "value2");
            Assert.AreEqual(cache.Get("key1"), "value2"); //check replace logic for the same key

            cache.AddOrReplace("key2", "value2");
            Assert.AreEqual(cache.Get("key2"), "value2");

            cache.AddOrReplace("key3", "value3");
            Assert.AreEqual(cache.Get("key3"), "value3");

            cache.AddOrReplace("key4", "value4");
            Assert.AreEqual(cache.Get("key4"), "value4");

            Assert.IsNull(cache.Get("key1")); //check LRU logic for max entry

            cache.AddOrReplace("key5", "value5");
            Assert.AreEqual(cache.Get("key5"), "value5");

            Assert.IsNull(cache.Get("key2")); //check LRU logic for max entry

            cache.Remove("key5");
            Assert.IsNull(cache.Get("key5")); //check remove logic 
        }

        [TestMethod]
        public void Test_MRU()
        {

            var numEntry = 3;

            var cache = new ObjectCache<string, string>(new MRUCache<string, string>(numEntry));

            cache.AddOrReplace("key1", "value1");
            Assert.AreEqual(cache.Get("key1"), "value1");

            cache.AddOrReplace("key1", "value2");
            Assert.AreEqual(cache.Get("key1"), "value2"); //check replace logic for the same key

            cache.AddOrReplace("key2", "value2");
            Assert.AreEqual(cache.Get("key2"), "value2");

            cache.AddOrReplace("key3", "value3");
            Assert.AreEqual(cache.Get("key3"), "value3");

            cache.AddOrReplace("key4", "value4");
            Assert.AreEqual(cache.Get("key4"), "value4");

            Assert.IsNull(cache.Get("key3")); //check MRU logic for max entry

            cache.AddOrReplace("key5", "value5");
            Assert.AreEqual(cache.Get("key5"), "value5");

            Assert.IsNull(cache.Get("key4")); //check MRU logic for max entry

            cache.Remove("key5");
            Assert.IsNull(cache.Get("key5")); //check remove logic 
        }
    }
}
