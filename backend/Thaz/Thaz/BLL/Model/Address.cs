using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class Address
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("address")]
        public string AddressLine { get; set; }
        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}