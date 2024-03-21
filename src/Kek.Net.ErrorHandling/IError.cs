namespace Kek.Net.ErrorHandling;

/// <summary>
/// If a reason for a <see cref="IResult"/> is the cause of a failure, it is an error.
/// </summary>
public interface IError : IReason
{
    
}