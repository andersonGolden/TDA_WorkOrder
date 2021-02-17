using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TDAWorkOrderAPI.ViewModel.SetUpViewModels
{
    public class MeasurementsViewModel
    {
        public long Id { get; set; }
        public double Neck { get; set; }
        public double Back { get; set; }
        public double Hand { get; set; }
        public double Chest { get; set; }
        public double Stomach { get; set; }
        public double TopLength { get; set; }
        public double Hips { get; set; }
        [Description("R/S")]
        public double R_S { get; set; }

        public double Waist { get; set; }
        public double Thigh { get; set; }
        public double Sit { get; set; }
        public double Bottom { get; set; }
        public double Calf { get; set; }
        public double TrouserLength { get; set; }

        public double AgbadaLength { get; set; }
        public double AgbadaWidth{ get; set; }
        public double Head { get; set; }
    }
}
