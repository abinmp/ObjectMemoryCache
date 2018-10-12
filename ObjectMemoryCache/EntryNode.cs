
namespace ObjectMemoryCache
{
    internal class EntryNode<TKey, TValue>
    {
        internal TKey Key { get; set; }
        internal TValue Value { get; set; }
    }
}
