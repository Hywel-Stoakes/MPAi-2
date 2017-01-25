using System.Collections;

namespace MPAi.Cores
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Converts a non-generic collection to an array.
        /// </summary>
        public static T[] ToArray<T>(this ICollection collection)
        {
         var items = new T[collection.Count];
            collection.CopyTo(items, 0);
    
            return items;
        }
    }
}
