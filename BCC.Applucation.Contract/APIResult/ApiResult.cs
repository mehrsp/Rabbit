using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BCC.Application.Contract.APIResult;

public class ApiResult
{
    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public bool IsSuccess { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Include)]
    public ApiResultStatusCode StatusCode { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public object Data { get; set; }

    public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, string message = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Message = message ?? statusCode.ToString();
    }
    public static ApiResult Success()
    {
        return new ApiResult(true, ApiResultStatusCode.Success);
    }

    public static ApiResult ServerError(string message = null)
    {
        return new ApiResult(false, ApiResultStatusCode.ServerError, message);
    }

    public static ApiResult NotFound(string message = null)
    {
        return new ApiResult(false, ApiResultStatusCode.NotFound, message);
    }
    public static ApiResult AccessViolation(string message = null)
    {
        return new ApiResult(false, ApiResultStatusCode.UnAuthorized, message);
    }

    #region Implicit Operators
    public static implicit operator ApiResult(OkResult _)
    {
        return new ApiResult(true, ApiResultStatusCode.Success);
    }

    public static implicit operator ApiResult(BadRequestResult _)
    {
        return new ApiResult(false, ApiResultStatusCode.BadRequest);
    }

    public static implicit operator ApiResult(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResult(false, ApiResultStatusCode.BadRequest, message);
    }

    public static implicit operator ApiResult(ContentResult result)
    {
        return new ApiResult(true, ApiResultStatusCode.Success, result.Content);
    }

    public static implicit operator ApiResult(NotFoundResult _)
    {
        return new ApiResult(false, ApiResultStatusCode.NotFound);
    }
    public static implicit operator ApiResult(UnauthorizedResult _)
    {
        return new ApiResult(false, ApiResultStatusCode.UnAuthorized);
    }
    #endregion
}

public class ApiResult<TData> : ApiResult
    where TData : class
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public new TData Data { get; set; }

    public ApiResult(bool isSuccess, ApiResultStatusCode statusCode, TData data, string message = null)
        : base(isSuccess, statusCode, message)
    {
        Data = data;
    }

    public static ApiResult<TData> Success(TData data, string message = null)
    {
        return new ApiResult<TData>(true, ApiResultStatusCode.Success, data, message);
    }

    #region Implicit Operators
    public static implicit operator ApiResult<TData>(TData data)
    {
        return new ApiResult<TData>(true, ApiResultStatusCode.Success, data);
    }

    public static implicit operator ApiResult<TData>(OkResult _)
    {
        return new ApiResult<TData>(true, ApiResultStatusCode.Success, null);
    }

    public static implicit operator ApiResult<TData>(OkObjectResult result)
    {
        return new ApiResult<TData>(true, ApiResultStatusCode.Success, (TData)result.Value);
    }

    public static implicit operator ApiResult<TData>(BadRequestResult _)
    {
        return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, null);
    }

    public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiResult<TData>(false, ApiResultStatusCode.BadRequest, null, message);
    }

    public static implicit operator ApiResult<TData>(ContentResult result)
    {
        return new ApiResult<TData>(true, ApiResultStatusCode.Success, null, result.Content);
    }

    public static implicit operator ApiResult<TData>(NotFoundResult _)
    {
        return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, null);
    }

    public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
    {
        return new ApiResult<TData>(false, ApiResultStatusCode.NotFound, (TData)result.Value);
    }
    public static implicit operator ApiResult<TData>(UnauthorizedObjectResult result)
    {
        return new ApiResult<TData>(false, ApiResultStatusCode.UnAuthorized, (TData)result.Value);
    }
    #endregion
}

public class ApiStructResult<TStruct> : ApiResult
    where TStruct : struct
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public new TStruct Data { get; set; }

    public ApiStructResult(bool isSuccess, ApiResultStatusCode statusCode, TStruct data, string message = null)
        : base(isSuccess, statusCode, message)
    {
        Data = data;
    }

    #region Implicit Operators
    public static implicit operator ApiStructResult<TStruct>(TStruct data)
    {
        return new ApiStructResult<TStruct>(true, ApiResultStatusCode.Success, data);
    }

    public static implicit operator ApiStructResult<TStruct>(OkResult _)
    {
        return new ApiStructResult<TStruct>(true, ApiResultStatusCode.Success, default);
    }

    public static implicit operator ApiStructResult<TStruct>(OkObjectResult result)
    {
        return new ApiStructResult<TStruct>(true, ApiResultStatusCode.Success, (TStruct)result.Value);
    }

    public static implicit operator ApiStructResult<TStruct>(BadRequestResult _)
    {
        return new ApiStructResult<TStruct>(false, ApiResultStatusCode.BadRequest, default);
    }

    public static implicit operator ApiStructResult<TStruct>(BadRequestObjectResult result)
    {
        var message = result.Value.ToString();
        if (result.Value is SerializableError errors)
        {
            var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
            message = string.Join(" | ", errorMessages);
        }
        return new ApiStructResult<TStruct>(false, ApiResultStatusCode.BadRequest, default, message);
    }

    public static implicit operator ApiStructResult<TStruct>(ContentResult result)
    {
        return new ApiStructResult<TStruct>(true, ApiResultStatusCode.Success, default, result.Content);
    }

    public static implicit operator ApiStructResult<TStruct>(NotFoundResult _)
    {
        return new ApiStructResult<TStruct>(false, ApiResultStatusCode.NotFound, default);
    }

    public static implicit operator ApiStructResult<TStruct>(NotFoundObjectResult result)
    {
        return new ApiStructResult<TStruct>(false, ApiResultStatusCode.NotFound, (TStruct)result.Value);
    }
    public static implicit operator ApiStructResult<TStruct>(UnauthorizedObjectResult result)
    {
        return new ApiStructResult<TStruct>(false, ApiResultStatusCode.UnAuthorized, (TStruct)result.Value);
    }
    #endregion
}


