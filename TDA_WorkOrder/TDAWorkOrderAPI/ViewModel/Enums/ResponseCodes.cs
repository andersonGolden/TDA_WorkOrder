using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDAWorkOrderAPI.ViewModel.Enums
{
    public enum ResponseCodes
    {
        Ok = 200,
        BadRequest = 400,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
