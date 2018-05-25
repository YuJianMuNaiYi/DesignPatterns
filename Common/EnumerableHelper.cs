using System;
using System.Collections.Generic;

namespace Common
{
    public static class EnumerableHelper
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            if (sequence == null) throw new ArgumentNullException("sequence");
            if (action == null) throw new ArgumentNullException("action");
            foreach (T item in sequence)
            {
                action(item);
            }
        }
    }
}