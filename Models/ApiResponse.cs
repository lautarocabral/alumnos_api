namespace alumnos_api.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }

        public ApiResponse(int statusCode, string message, object result = null)
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}
