﻿namespace Library.BL;

public class ApiResult<T>
{
    public bool Succeeded { get; }

    public T Result { get; }

    public IEnumerable<string> Errors { get; set; }

    private ApiResult(bool succeeded, T result, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Result = result;
        Errors = errors; 
    }
    
    public static ApiResult<T> Success(T result) =>
        new(true, result, new List<string>());

    public static ApiResult<T> Failure(IEnumerable<string> errors) =>
        new(false, default, errors);

}
