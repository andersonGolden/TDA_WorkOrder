using System;
using System.Collections.Generic;
using System.Text;

namespace TDADomain.BaseDataObjects
{
    public class DefaultDTO
    {
        public long ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
