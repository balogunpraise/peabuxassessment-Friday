namespace Presentation.Wrappers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message;
            Succeeded = true;
        }
    }



    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; init; }
        public ApiResponse(T data, int statusCode, string message = null) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
