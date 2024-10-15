namespace Kek.Net.ErrorHandling;

/// <summary>
/// A type of <see cref="Error"/> that captures an exception.
/// </summary>
public class ExceptionalError : Error
{
    /// <summary>
    /// The captured exception.
    /// </summary>
    public Exception Exception { get; }
    
    public ExceptionalError(Exception ex) : base(ex.Message)
    {
        Exception = ex;
    }

    /// <summary>
    /// Implicit conversion for an <see cref="System.Exception"/> to an <see cref="ExceptionalError"/>.
    /// </summary>
    /// <param name="ex">The exception.</param>
    public static implicit operator ExceptionalError(Exception ex)
    {
        return new ExceptionalError(ex);
    }
}