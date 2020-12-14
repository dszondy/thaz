using System;

namespace Thaz.BLL.QueryObjects
{
    public class AccountingParams
    {
        public int? PartnerId { get; set; }
        public int? CondominiumId { get; set; }
        
        public string Tag { get; set; }
    }
}