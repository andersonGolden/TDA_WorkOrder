using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDAWorkOrderAPI.ViewModel;
using TDAWorkOrderAPI.ViewModel.Enums;

namespace TDAWorkOrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleError(Exception ex)
        {

            var response = new ApiResponse<string>();

            response.statusCode = ResponseCodes.InternalServerError;
            response.description = StaticMessages.ErrorMessage;
            return Ok(response);
        }
    }
}
