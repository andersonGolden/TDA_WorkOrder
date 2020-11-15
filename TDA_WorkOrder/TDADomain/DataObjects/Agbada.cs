using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class Agbada : DefaultDTO
    {
        [Description("Agbada L")]
        public double L { get; set; }
        [Description("Agbada W")]
        public double W { get; set; }
        public double Head { get; set; }
    }
}
