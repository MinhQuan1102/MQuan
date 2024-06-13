namespace api.DTOModels
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Payload { get; set; }

        public ApiResponse() 
        {
            Status = 200;
            Message = "";
            Payload = null;
        }

        public static ApiResponse Success(object? data = null)
        {
            return new ApiResponse
            {
                Status = 200,
                Payload = data
            };
        }

        public static ApiResponse BadRequest(string message) 
        {
            return new ApiResponse
            {
                Status = 400,
                Message = message,
            };
        }

        public static ApiResponse Unauthorized(string message)
        {
            return new ApiResponse
            {
                Status = 401,
                Message = message,
            };
        }
    }
}
