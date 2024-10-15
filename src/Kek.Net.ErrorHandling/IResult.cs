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

public interface IResult<out TData> : IResult
{
    /// <summary>
    /// Gets the return value of the operation, if successful. 
    /// </summary>
    /// <exception cref="InvalidOperationException">When trying to get the data of an unsuccessful operation.</exception>
    TData? Data { get; }
}