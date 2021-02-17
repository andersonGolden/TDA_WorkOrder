using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAWorkOrderAPI.ViewModel.Enums;

namespace TDAWorkOrderAPI.ViewModel
{
    public class ResponseMessage
    {
        public static ApiResponse<T> SuccessResponse<T>(T data, string message = null)
        {
            return new ApiResponse<T>
            {

                statusCode = ResponseCodes.Ok,
                description = message ?? StaticMessages.DefaultSuccess,
                payload = data,
                success = true
            };
        }

        public static ApiResponse<T> ErrorResponse<T>(string message = null)
        {
            return new ApiResponse<T>
            {

                statusCode = ResponseCodes.BadRequest,
                description = message ?? StaticMessages.ErrorMessage,
                success = false
            };
        }

        public static ApiResponse<T> ExceptionResponse<T>(string message = null)
        {
            return new ApiResponse<T>
            {

                statusCode = ResponseCodes.InternalServerError,
                description = message ?? StaticMessages.ErrorMessage,
                success = false
            };
        }
    }
}
