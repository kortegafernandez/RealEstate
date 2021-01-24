namespace RealEstate.Api.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
            IsSuccess = true;
        }

        public ApiResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }

        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
