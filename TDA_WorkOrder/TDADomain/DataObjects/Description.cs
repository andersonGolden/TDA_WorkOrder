using System;
using System.Collections.Generic;
using System.Text;
using TDADomain.BaseDataObjects;
using static TDADomain.BaseDataObjects.Enums;

namespace TDADomain.DataObjects
{
    public class Description : DefaultDTO
    {
        public long StyleId { get; set; }
        public virtual Style Style { get; set; }
        public long CuffId { get; set; }
        public virtual Cuffs Cuffs { get; set; }
        public long SleeveId { get; set; }
        public virtual Sleeve Sleeve { get; set; }
        public long NeckId { get; set; }
        public virtual Neck Neck { get; set; }
        public long FlapId { get; set; }
        public virtual Flap Flap { get; set; }
        public long EmbroideryId { get; set; }
        public virtual Embroidery Embroidery { get; set; }
        public Underlay Underlay { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public BackDetailing BackDetailing { get; set; }
        public long ChestPocketId { get; set; }
        public virtual ChestPocket ChestPocket { get; set; }
        public BackDetailing SidePocket { get; set; }
        public long TrousersId { get; set; }
        public virtual Trousers Trousers { get; set; }
    }
}
