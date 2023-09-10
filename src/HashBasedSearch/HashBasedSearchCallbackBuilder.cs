﻿namespace HashBasedSearch;

public static class HashBasedSearchCallbackBuilder
{
    
    #region Without elementSelector, without comparer

    
    public static HashBasedSearchCallback<TSource?, TKey> BuildHashBasedSearchCallback<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        where TKey : notnull
    {
        Dictionary<TKey, TSource> dictionary = source.ToDictionary(keySelector);

        TSource? GetValueOrDefault(TKey key)
        {
            dictionary.TryGetValue(key, out TSource? value);
            return value;
        }

        return GetValueOrDefault;
    }

    public static HashBasedSearchCallback<TSource, TKey> BuildHashBasedSearchCallback<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TSource defaultValue)
        where TKey : notnull
    {
        Dictionary<TKey, TSource> dictionary = source.ToDictionary(keySelector);

        TSource GetValueOrDefault(TKey key)
        {
            bool found = dictionary.TryGetValue(key, out TSource? value);
            if (found)
                return value!;

            return defaultValue;
        }

        return GetValueOrDefault;
    }

    #endregion


    #region With elementSelector, without comparer

    
    public static HashBasedSearchCallback<TElement?, TKey> BuildHashBasedSearchCallback<TSource, TElement, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        where TKey : notnull
    {
        Dictionary<TKey, TElement> dictionary = source.ToDictionary(keySelector, elementSelector);

        TElement? GetValueOrDefault(TKey key)
        {
            dictionary.TryGetValue(key, out TElement? value);
            return value;
        }

        return GetValueOrDefault;
    }


    public static HashBasedSearchCallback<TElement, TKey> BuildHashBasedSearchCallback<TSource, TElement, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, TElement defaultValue)
        where TKey : notnull
    {
        Dictionary<TKey, TElement> dictionary = source.ToDictionary(keySelector, elementSelector);

        TElement? GetValueOrDefault(TKey key)
        {
            bool found = dictionary.TryGetValue(key, out TElement? value);
            if (found)
                return value!;

            return defaultValue;
        }

        return GetValueOrDefault;
    }

    #endregion
    
    
    #region Without elementSelector, with comparer
    
    public static HashBasedSearchCallback<TSource?, TKey> BuildHashBasedSearchCallback<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer)
        where TKey : notnull
    {
        Dictionary<TKey, TSource> dictionary = source.ToDictionary(keySelector,  comparer);

        TSource? GetValueOrDefault(TKey key)
        {
            dictionary.TryGetValue(key, out TSource? value);
            return value;
        }

        return GetValueOrDefault;
    }
    

    public static HashBasedSearchCallback<TSource, TKey> BuildHashBasedSearchCallback<TSource, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer, TSource defaultValue)
        where TKey : notnull
    {
        Dictionary<TKey, TSource> dictionary = source.ToDictionary(keySelector, comparer);

        TSource GetValueOrDefault(TKey key)
        {
            bool found = dictionary.TryGetValue(key, out TSource? value);
            if (found)
                return value!;

            return defaultValue;
        }

        return GetValueOrDefault;
    }

    #endregion
    
    
    #region With elementSelector, with comparer

    
    public static HashBasedSearchCallback<TElement?, TKey> BuildHashBasedSearchCallback<TSource, TElement, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer)
        where TKey : notnull
    {
        Dictionary<TKey, TElement> dictionary = source.ToDictionary(keySelector, elementSelector, comparer);

        TElement? GetValueOrDefault(TKey key)
        {
            dictionary.TryGetValue(key, out TElement? value);
            return value;
        }

        return GetValueOrDefault;
    }


    public static HashBasedSearchCallback<TElement, TKey> BuildHashBasedSearchCallback<TSource, TElement, TKey>(
        this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer, TElement defaultValue)
        where TKey : notnull
    {
        Dictionary<TKey, TElement> dictionary = source.ToDictionary(keySelector, elementSelector, comparer);

        TElement? GetValueOrDefault(TKey key)
        {
            bool found = dictionary.TryGetValue(key, out TElement? value);
            if (found)
                return value!;

            return defaultValue;
        }

        return GetValueOrDefault;
    }

    #endregion
    
}