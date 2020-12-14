using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class TransactionDetails : Transaction
    {
        [JsonPropertyName("condominium")]
        public Condominium Condominium {get; set; }
        
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }
    }
}