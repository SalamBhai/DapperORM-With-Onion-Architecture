namespace Application.DTOs.ResponseModels;

public class BaseResponse
{
    public string Message {get; set;}
    public bool IsSuccessful {get; set;}
}

public  class BaseResponse<TData> : BaseResponse
{
    public TData Data {get; set;}
}