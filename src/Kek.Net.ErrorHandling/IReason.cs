namespace Kek.Net.ErrorHandling;

/// <summary>
/// A reason for the <see cref="IResult"/> status.
/// </summary>
public interface IReason
{
    /// <summary>
    /// The message describing the reason.
    /// </summary>
    string Message { get; }
    /// <summary>
    /// Optional metadata accompanying the reason.
    /// </summary>
    IDictionary<string, object?> Metadata { get; }
}