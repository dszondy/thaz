using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class Partner
    {
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        
        
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("is_resident")]
        public bool IsResident { get; set; }

        [JsonPropertyName("is_supplier")]
        public bool IsSupplier { get; set; }
    }
}