﻿using System;
using System.Collections.Generic;

namespace GameCore
{
    public static class IntExtensions
    {
        public static bool ToBool(this int value)
        {
            return value > 0;
        }

        public static bool In(this int number, params int[] values)
        {
            foreach (var value in values)
            {
                if (number == value)
                    return true;
            }

            return false;
        }
    }

    public static class IListExtensions
    {
        public static void ForEachCombination<T>(
            this IList<T> items,
            Action<T, T> callback)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = items.Count - 1; j > i; j--)
                {
                    callback(items[i], items[j]);
                }
            }
        }

        public static void ForEachCombination<T>(
            this IList<T> a,
            IList<T> b,
            Action<T, T> callback)
        {
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++)
                {
                    callback(a[i], b[j]);
                }
            }
        }
    }
}
