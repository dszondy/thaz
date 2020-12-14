using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class CondominiumTotals: Condominium
    {
        [JsonPropertyName("bills")]
        public double Bills { get; set; }
        
        [JsonPropertyName("transactions")]
        public double Transactions { get; set; }
    }
}