

namespace BCC.Application.Contract.APIResult;


public class ServiceResult
{
    public bool IsSuccess { get; set; }
    public ApiResultStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    public ServiceResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToString();
    }

    #region static Methods

    public static ServiceResult Success(string message = null)
    {
        return new ServiceResult(true, ApiResultStatusCode.Success, message);
    }
    public static ServiceResult BadRequest(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.BadRequest, message);
    }

    public static ServiceResult ServerError(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.ServerError, message);
    }


    public static ServiceResult NotFound(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.NotFound, message);
    }

    public static ServiceResult Found(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.Found, message);
    }
    public static ServiceResult NoAffectedRow(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.NoAffectedRow, message);
    }

    public static ServiceResult LogicError(string message = null)
    {
        return new ServiceResult(false, ApiResultStatusCode.LogicError, message);
    }


    #endregion
}

public class ServiceResult<TData> : ServiceResult
    where TData : class
{
    public TData Data { get; set; }

    public ServiceResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, string message = null)
        : base(isSuccess, statusCode, message)
    {
        Data = data;
    }

    #region static Methods

    public static ServiceResult<TData> Success(TData data = null, string message = null)
    {
        return new ServiceResult<TData>(true, ApiResultStatusCode.Success, data, message);
    }

    public static ServiceResult<TData> BadRequest(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.BadRequest, data, message);
    }
    public static ServiceResult<TData> NoAffectedRow(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.NoAffectedRow, data, message);
    }

    public static ServiceResult<TData> NotFound(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.NotFound, data, message);
    }
    public static ServiceResult<TData> Found(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.Found, data, message);
    }

    public static new ServiceResult<TData> ServerError(string message = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.ServerError, null, message);
    }
    public static ServiceResult<TData> ServerError(TData data, string message = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.ServerError, data, message);
    }

    public static ServiceResult<TData> ListEmpty(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.ListEmpty, data, message);
    }
    public static ServiceResult<TData> ListEmpty(TData data)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.ListEmpty, data, null);
    }
    public static ServiceResult<TData> ListEmpty(bool isSuccess, TData data)
    {
        return new ServiceResult<TData>(isSuccess, ApiResultStatusCode.ListEmpty, data, null);
    }
    public static ServiceResult<TData> LogicError(string message = null, TData data = null)
    {
        return new ServiceResult<TData>(false, ApiResultStatusCode.LogicError, data, message);
    }

    #endregion

    #region Implicit Operators
    public static implicit operator ServiceResult<TData>(TData data)
    {
        return Success(data);
    }
    public static implicit operator ServiceResult<TData>(Exception exception)
    {
        return ServerError(exception.Message);
    }
    #endregion
}
