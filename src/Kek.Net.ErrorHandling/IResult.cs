namespace Kek.Net.ErrorHandling;

/// <summary>
/// Interface describing a result of an operation.
/// </summary>
public interface IResult
{
    /// <summary>
    /// Indicates the operation is a success.
    /// </summary>
    bool IsSuccess { get; }
    /// <summary>
    /// Any errors the operation might have caused.
    /// </summary>
    ICollection<IError> Errors { get; }
    /// <summary>
    /// Any reasons for the operation result
    /// </summary>
    ICollection<IReason> Reasons { get; }
}