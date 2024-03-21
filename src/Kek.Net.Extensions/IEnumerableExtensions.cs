namespace System.Collections.Generic;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Flattens a tree of <typeparamref name="TItem"/> to an <see cref="IEnumerable{T}"/> of <typeparamref name="TItem"/>.
    /// </summary>
    /// <param name="collection">The collection of <typeparamref name="TItem"/>s to operate on.</param>
    /// <param name="navigator"></param>
    /// <typeparam name="TItem">The item type of the collection.</typeparam>
    /// <exception cref="ArgumentNullException">If <paramref name="collection"/> or <paramref name="navigator"/> are null.</exception>
    /// <returns>If the input collection is empty, returns an empty IEnumerable. Otherwise, returns the flattened collection</returns>
    public static IEnumerable<TItem> Flatten<TItem>(this IEnumerable<TItem> collection,
        Func<TItem, IEnumerable<TItem>> navigator)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(navigator);

        if (!collection.Any())
        {
            return Array.Empty<TItem>();
        }
        
        return collection.SelectMany(item => navigator(item).Flatten(navigator));
    }
}