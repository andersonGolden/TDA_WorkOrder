using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TDAWorkOrderAPI.ViewModel.SetUpViewModels
{
    public class WorkOrderViewModel
    {
        public long Id { get; set; }
        public CustomerViewModel Customer { get; set; }
        public DescriptionViewModel Description { get; set; }
        public MeasurementsViewModel Measurement { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        [Description("M.C")]
        public string MC { get; set; }
        [Description("CUT")]
        public string Cut { get; set; }
        [Description("TOP")]
        public string Top { get; set; }
        [Description("TRO")]
        public string Tro { get; set; }
        [Description("OTHERS")]
        public string Others { get; set; }
        [Description("FIN/BUTTON")]
        public string Fin_Button { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
