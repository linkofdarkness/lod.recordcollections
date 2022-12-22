﻿namespace System.Linq;

/// <summary>
/// A static utility exposing queries for <see cref="IEnumerable{T}"/>s for record-type collections similar to <see cref="Enumerable"/>.
/// </summary>
public static class RecordEnumerable
{
    /// <summary>
    /// Creates a <see cref="RecordList{T}"/> from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The record element type.</typeparam>
    /// <param name="enumerable">The enumerable sequence of records.</param>
    /// <returns>A <see cref="RecordList{T}"/> that contains the record elements from the input <paramref name="enumerable"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumerable"/> is null.</exception>
    public static RecordList<T> ToRecordList<T>(this IEnumerable<T> enumerable) where T : IEquatable<T> =>
        enumerable != null ? new RecordList<T>(enumerable) : throw new ArgumentNullException(nameof(enumerable));

    /// <summary>
    /// Creates a <see cref="RecordDictionary{TKey, TValue}"/> according to a specified key selector delegate.
    /// </summary>
    /// <typeparam name="TSource">The record element type.</typeparam>
    /// <typeparam name="TKey">The dictionary key type.</typeparam>
    /// <param name="enumerable">The enumerable sequence of records.</param>
    /// <param name="keySelector">The delegate function which identifies the key for each element.</param>
    /// <returns>A <see cref="RecordDictionary{TKey, TValue}"/> containing the sequence keys and elements.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumerable"/> or <paramref name="keySelector"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="keySelector"/> produces dulicate keys for two or more elements.</exception>
    public static RecordDictionary<TKey, TSource> ToRecordDictionary<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector) where TSource : IEquatable<TSource> =>
        enumerable != null && keySelector != null ? new RecordDictionary<TKey, TSource>(enumerable.Select(e => new KeyValuePair<TKey, TSource>(keySelector(e), e))) : throw new ArgumentNullException();

    /// <summary>
    /// Creates a <see cref="RecordDictionary{TKey, TValue}"/> according to a specified key selector delegate.
    /// </summary>
    /// <typeparam name="TSource">The record element type.</typeparam>
    /// <typeparam name="TKey">The dictionary key type.</typeparam>
    /// <typeparam name="TValue">The record value type.</typeparam>
    /// <param name="enumerable">The enumerable sequence of records.</param>
    /// <param name="keySelector">The delegate function which identifies the key for each element.</param>
    /// <param name="elementSelector">The delegate function which identifies the value for each element.</param>
    /// <returns>A <see cref="RecordDictionary{TKey, TValue}"/> containing the sequence keys and elements.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumerable"/>, <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="keySelector"/> produces dulicate keys for two or more elements.</exception>
    public static RecordDictionary<TKey, TValue> ToRecordDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector) where TValue : IEquatable<TValue> =>
        enumerable != null && keySelector != null && elementSelector != null ? new RecordDictionary<TKey, TValue>(enumerable.Select(e => new KeyValuePair<TKey, TValue>(keySelector(e), elementSelector(e)))) : throw new ArgumentNullException();

    /// <summary>
    /// Creates a <see cref="RecordSet{T}"/> from an <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The record element type.</typeparam>
    /// <param name="enumerable">The enumerable sequence of records.</param>
    /// <returns>A <see cref="RecordSet{T}"/> that contains the record elements from the input <paramref name="enumerable"/>.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="enumerable"/> is null.</exception>
    public static RecordSet<T> ToRecordSet<T>(this IEnumerable<T> enumerable) where T : IEquatable<T> =>
        enumerable != null ? new RecordSet<T>(enumerable) : throw new ArgumentNullException(nameof(enumerable));
}
