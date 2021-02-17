using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDAWorkOrderAPI.ViewModel.SetUpViewModels
{
    public class CustomerViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
