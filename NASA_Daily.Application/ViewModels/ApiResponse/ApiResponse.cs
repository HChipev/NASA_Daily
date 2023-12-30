namespace NASA_Daily.Domain.ViewModels.ApiResponse
{
    public class ApiResponse<T>
    {
        public ApiResponse(bool isSuccess, T? data, string? errorMessage = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccess { get; }
        public T? Data { get; }
        public string? ErrorMessage { get; }
    }
}