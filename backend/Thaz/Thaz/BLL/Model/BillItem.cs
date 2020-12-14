using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class BillItem
    {

        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}