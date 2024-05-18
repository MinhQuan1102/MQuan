namespace api.DTOModels
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public object? Payload { get; set; }

        public ApiResponse() 
        {
            Status = 200;
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
    }
}
