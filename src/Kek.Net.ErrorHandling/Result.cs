using System.Runtime.CompilerServices;

namespace Kek.Net.ErrorHandling;

public class Result : ResultBase
{

    /// <summary>
    /// Add the given reasons to the current result.
    /// </summary>
    /// <param name="reasons">A collection of <see cref="IReason"/>s.</param>
    /// <seealso cref="IReason"/>
    /// <returns>The modified result.</returns>
    public Result WithReasons(ICollection<IReason> reasons)
    {
        if (reasons is null or { Count: 0 })
        {
            return this;
        }

        Reasons = Reasons is { Count: 0 } ? reasons : Reasons.Concat(reasons).ToList();

        return this;
    }

    /// <summary>
    /// Creates a result signifying operation success with return data.
    /// </summary>
    /// <param name="data">The data returned from the successful operation.</param>
    /// <typeparam name="TData">The type of the return data</typeparam>
    /// <returns>A result signaling operation success containing the operation's return data.</returns>
    public static Result<TData> Ok<TData>(TData data)
    {
        return new Result<TData>(data);
    }

    /// <summary>
    /// Creates a result signalling a successful operation.
    /// </summary>
    /// <returns>A <see cref="Result"/> with IsSuccess set to true.</returns>
    public static Result Ok()
    {
        return new Result();
    }

    public static Result<TData> Ok<TData>()
    {
        return new Result<TData>();
    }

    /// <summary>
    /// Creates a <see cref="Result"/> with the given error that indicates a failure.
    /// </summary>
    /// <param name="error">The description of the failure.</param>
    /// <returns>The result signaling operation failure.</returns>
    public static Result Fail(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return Fail([error]);
    }

    /// <summary>
    /// Creates a <see cref="Result"/> with the given errors that indicates a failure.
    /// </summary>
    /// <param name="errors">A list of errors specifying the failure.</param>
    /// <returns>The result signaling operation failure.</returns>
    public static Result Fail(params IError[] errors)
    {
        ArgumentNullException.ThrowIfNull(errors);
        
        return new Result().WithReasons(errors);
    }

    /// <summary>
    /// Creates a <see cref="Result"/> with the given error that indicates a failure.
    /// </summary>
    /// <param name="error">The description of the failure.</param>
    /// <returns>The result signaling operation failure.</returns>
    public static Result<TData> Fail<TData>(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        return Fail<TData>([error]);
    }

    /// <summary>
    /// Creates a <see cref="Result"/> with the given errors that indicates a failure.
    /// </summary>
    /// <param name="errors">A list of errors specifying the failure.</param>
    /// <returns>The result signaling operation failure.</returns>
    public static Result<TData> Fail<TData>(params IError[] errors)
    {
        ArgumentNullException.ThrowIfNull(errors);

        return new Result<TData>().WithReasons(errors);
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to a typed <see cref="Result{TData}"/>.
    /// </summary>
    /// <typeparam name="TData">The type of return data.</typeparam>
    /// <returns>A <see cref="Result{TData}"/> with return data of type <typeparamref name="TData"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Result<TData> ToResult<TData>()
    {
        return new Result<TData>().WithReasons(Reasons);
    }
}

/// <summary>
/// An operation result with possible return data.
/// </summary>
/// <typeparam name="TData">The type of return data.</typeparam>
public class Result<TData> : ResultBase, IResult<TData>
{
    internal Result(TData data)
    {
        _value = data;
    }

    internal Result()
    {
        _value = default;
    }

    private readonly TData? _value;

    /// <inheritdoc cref="IResult{TData}"/>
    public TData? Data
    {
        get
        {
            if (!IsSuccess)
            {
                throw new InvalidOperationException("Cannot get return value if result is not successful.");
            }

            return _value;
        }
    }

    /// <summary>
    /// Add the given reasons to the current result.
    /// </summary>
    /// <param name="reasons">A collection of <see cref="IReason"/>s.</param>
    /// <seealso cref="IReason"/>
    /// <returns>The modified result.</returns>
    public Result<TData> WithReasons(ICollection<IReason> reasons)
    {
        if (reasons is null or { Count: 0 })
        {
            return this;
        }

        Reasons = Reasons is { Count: 0 } ? reasons : Reasons.Concat(reasons).ToList();

        return this;
    }

    /// <summary>
    /// Implicitly convert an untyped <see cref="Result"/> to a typed result without data. 
    /// </summary>
    /// <param name="result">The original result.</param>
    /// <returns>A typed result.</returns>
    public static implicit operator Result<TData>(Result result)
    {
        return result.ToResult<TData>();
    }

    /// <summary>
    /// Implicitly convert any type <typeparamref name="TData"/> to a success result with that data.
    /// </summary>
    /// <param name="data">The operation result data.</param>
    /// <returns>If <typeparamref name="TData"/> is of type <see cref="Result{TData}"/> then it is returned verbatim,
    /// otherwise a successful result containing <paramref name="data"/> is returned.</returns>
    public static implicit operator Result<TData>(TData data)
    {
        if (data is Result<TData> r) return r;

        return Result.Ok(data);
    }

    /// <summary>
    /// Converts a typed result to an untyped result.
    /// </summary>
    /// <returns>A <see cref="Result"/> containing the success and reasons of the parent result, but not the return data.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Result ToResult()
    {
        return Result.Ok().WithReasons(Reasons);
    }
}