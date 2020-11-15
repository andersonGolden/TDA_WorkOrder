using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class Trouser : DefaultDTO
    {
        public double Waist { get; set; }
        public double Thigh { get; set; }
        public double Sit { get; set; }
        public double Bottom { get; set; }
        public double Calf { get; set; }
        [Description("Trouser Length")]
        public double Length { get; set; }
    }
}
