namespace Generic.Domain.Shared;

public class Result
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess;

    public string Message { get; private set; }
    public ErrorType? ErrorType { get; private set; }

    protected Result(bool isSuccess, string message, ErrorType? errorType = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        ErrorType = errorType;
    }

    public static Result Success(string message)
    {
        return new Result(true, message);
    }

    public static Result Failed(string message, ErrorType errorType)
    {
        return new Result(false, message, errorType);
    }
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    private Result(bool isSuccess, string message, T? data, ErrorType? errorType = null)
        : base(isSuccess, message, errorType)
    {
        Data = data;
    }

    public static Result<T> Success(string message,  T data)
    {
        return new Result<T>(true, message, data);
    }

    public new static Result<T> Failed(string message, ErrorType errorType)
    {
        return new Result<T>(false, message, default, errorType);
    }
}