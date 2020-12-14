using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class Balance
    {
        [JsonPropertyName("transactions_from_partner")]
        public double TransactionFromPartner { get; set; }
        
        [JsonPropertyName("transactions_to_partner")]
        public double TransactionToPartner { get; set; }
        
        [JsonPropertyName("bills_from_partner")]
        public double BillsFromPartner { get; set; }
        
        [JsonPropertyName("bills_to_partner")]
        public double BillsToPartner { get; set; }

    }
}