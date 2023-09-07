namespace Presentation.Wrappers
{
    public class ApiErrorResponse : ApiResponse
    {
        public ApiErrorResponse(int statusCode, string message = null) : base(statusCode, message)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Message = GenerateErrorMessage(statusCode);
        }

        private static string GenerateErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                404 => "Resource Not Found",
                401 => "Unauthorized",
                500 => "Server Error",
                _ => null
            }; 
        }
    }
}
