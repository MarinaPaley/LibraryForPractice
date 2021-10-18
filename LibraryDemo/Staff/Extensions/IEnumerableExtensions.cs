namespace Staff.Extensions
{
    using System.Collections.Generic;
    public static class IEnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> collection, string separator = ", ") =>
            string.Join(separator, collection);
    }
}
