namespace Kek.Net.ErrorHandling;

public class Error : IError
{
    public string Message { get; }
    public IDictionary<string, object?> Metadata { get; } = new Dictionary<string, object?>();

    /// <summary>
    /// Creates an error with the given message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public Error(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Adds metadata to the dictionary with the given <paramref name="key"/>.
    /// </summary>
    /// <param name="key">The key to store the metadata under.</param>
    /// <param name="data">The data to store.</param>
    /// <returns>The error containing the metadata.</returns>
    /// <exception cref="ArgumentException">If <paramref name="key"/> is null or whitespace.</exception>
    /// <exception cref="InvalidOperationException">If <paramref name="key"/> already exists in the metadata dictionary.</exception>
    public Error WithMetadata(string key, object data)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        return Metadata.TryAdd(key, data) ? this : throw new InvalidOperationException($"The key '{key}' is already taken as a metadata key.");
    }
}