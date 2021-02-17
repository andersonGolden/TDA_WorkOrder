using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDAWorkOrderAPI.ViewModel.Enums;

namespace TDAWorkOrderAPI.ViewModel
{
    public class ApiResponse<T>
    {
        public T payload { get; set; } = default(T);
        public bool success { get; set; }
        public ResponseCodes statusCode { get; set; }
        public string description { get; set; }
    }
}
