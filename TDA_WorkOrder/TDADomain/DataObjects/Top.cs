using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TDADomain.BaseDataObjects;

namespace TDADomain.DataObjects
{
    public class Top : DefaultDTO
    {
        public double Neck { get; set; }
        public double Back { get; set; }
        public double Hand { get; set; }
        public double Chest { get; set; }
        public double Stomach { get; set; }
        public double Length { get; set; }
        public double Hips { get; set; }
        [Description("R/S")]
        public double R_S { get; set; }
    }
}
