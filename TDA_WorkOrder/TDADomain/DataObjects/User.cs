using System;
using System.Collections.Generic;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class User : DefaultDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
