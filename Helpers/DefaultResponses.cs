using apisistec.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Helpers
{
    public class DefaultResponses : ControllerBase
    {
        public IActionResult SuccessResponse<T>(string message, T result)
        {
            return Ok(new DefaultResponseDto<T>
            {
                Success = true,
                Message = message,
                Result = result
            });
        }

        public IActionResult ErrorResponse<T>(string message, T? result)
        {
            return BadRequest(new DefaultResponseDto<T?>
            {
                Success = false,
                Message = message,
                Result = result
            }); 
        }
    }
}
