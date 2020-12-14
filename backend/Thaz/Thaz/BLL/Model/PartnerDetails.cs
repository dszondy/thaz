using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class PartnerDetails: Partner
    {
        [JsonPropertyName("condominiums")] 
        public IEnumerable<Condominium> Condominiums { get; set; }
    }
}