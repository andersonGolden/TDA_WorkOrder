using System;
using System.Collections.Generic;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class Measurement : DefaultDTO
    {
        public long TopId { get; set; }
        public virtual Top Top { get; set; }
        public long TrouserId { get; set; }
        public virtual Trouser Trouser { get; set; }
        public long AgbadaId { get; set; }
        public virtual Agbada Agbada { get; set; }
    }
}
