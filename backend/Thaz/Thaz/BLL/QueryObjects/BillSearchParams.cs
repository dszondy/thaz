using System;

namespace Thaz.BLL.QueryObjects
{
    public class BillSearchParams
    {
        public int? PartnerId { get; set; }
        public int Page { get; set; }
        public string SerialFilter { get; set; }
        public DateTime? DueAfter { get; set; }
        public DateTime? DueBefore { get; set; }
        public DateTime? IssuedAfter { get; set; }
        public DateTime? IssuedBefore { get; set; }
        public bool? IsDone { get; set; }
        public double? ValueMore { get; set; }
        public double? ValueLess { get; set; }
        public bool? IncludeCompletion { get; set; }
    }

}