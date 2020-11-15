using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TDADomain.BaseDataObjects
{
    public class Enums
    {
        public enum MeasurementType
        {
            [Description("TDA")]
            TDA,
            [Description("NOT TDA")]
            NOT_TDA
        }

        public enum BackDetailing
        {
            [Description("Yes")]
            Yes = 1,
            [Description("No")]
            No = 0
        }

        public enum Underlay
        {
            [Description("No")]
            No,
            [Description("Yes")]
            Yes,
            [Description("Subtle")]
            Subtle
        }

        public enum WorkOrderStatus
        {
            New = 0,
            Completed = 1
        }
    }
}
