using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TDADomain.BaseDataObjects;
using static TDADomain.BaseDataObjects.Enums;

namespace TDADomain.DataObjects
{
    public class WorkOrder : DefaultDTO
    {
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public long DescriptionId { get; set; }
        public virtual Description Description { get; set; }
        public long MeasurementId { get; set; }
        public virtual Measurement Measurement { get; set; }
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
        public WorkOrderStatus Status { get; set; }
    }
}
