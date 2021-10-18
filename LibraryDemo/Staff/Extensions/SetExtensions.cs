﻿namespace Staff.Extensions
{
    using System.Collections.Generic;

    public static class SetExtensions
    {
        public static bool? TryAdd<T>(this ISet<T> set, T value)
            where T : class
        {
            return value is null
                ? null
                : set.Add(value);
        }
    }
}
