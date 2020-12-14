using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    [Table("condominiums")]
    public class Condominium
    {
        [JsonPropertyName("name")]
        [Column("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        [Column("address")]
        public Address Address { get; set; }
        
        [JsonPropertyName("id")]
        [Column("id")]
        public int? Id { get; set; }
    }
}