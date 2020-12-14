using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class BillWithCompletion: Bill
    {
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("rate")]
        public double CompletionRate { get; set; }
    }
}