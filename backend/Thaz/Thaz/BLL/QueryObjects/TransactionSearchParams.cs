using System;

namespace Thaz.BLL.QueryObjects
{
    public class TransactionSearchParams
    {
        public int Page { get; set; }
        public DateTime? After { get; set; }
        public DateTime? Before { get; set; }
        public double? AmountLess { get; set; }
        public double? AmountMore { get; set; }
        public string AccountNumber { get; set; }
        public int? PartnerId { get; set; }
        public string TransactionIdentifier { get; set; }
    }
}