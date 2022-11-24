using apisistec.Dtos;

namespace apisistec.Helpers
{
    public class DefaultResponses
    {
        public DefaultResponseDto<T> SuccessResponse<T>(string message, T result)
        {
            return new DefaultResponseDto<T>
            {
                Success = true,
                Message = message,
                Result = result
            };
        }
        public DefaultResponseDto<T?> ErrorResponse<T>(string message, T? result)
        {
            return new DefaultResponseDto<T?>
            {
                Success = false,
                Message = message,
                Result = result
            };
        }
    }
}
