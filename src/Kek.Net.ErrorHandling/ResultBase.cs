namespace Kek.Net.ErrorHandling;

/// <summary>
/// Abstract implementation of <see cref="IResult"/>.
/// </summary>
public abstract class ResultBase : IResult
{
    /// <inheritdoc />
    public bool IsSuccess => Errors is { Count: 0 };
    /// <inheritdoc />
    public ICollection<IError> Errors => Reasons.OfType<IError>().ToList();
    /// <inheritdoc />
    public ICollection<IReason> Reasons { get; protected set; } = new List<IReason>();
}