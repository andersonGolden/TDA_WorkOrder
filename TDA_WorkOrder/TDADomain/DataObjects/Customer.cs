using System;
using System.Collections.Generic;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class Customer : DefaultDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public ICollection<WorkOrder> workOrders { get; set; }
    }
}
