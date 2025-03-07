namespace SimoshStore;

public class ServiceResult : IServiceResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ServiceResult()
    {
        Success = false;
        Message = string.Empty;
    }
    public ServiceResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}

public class ServiceResult<T> : ServiceResult, IServiceResult<T>
{
    public T Data {get; set;}
    public ServiceResult() : base()
    {
        Data = default!;
    }
    public ServiceResult(bool success, string message, T data) : base(success, message)
    {
        Data = data;
    }
}
