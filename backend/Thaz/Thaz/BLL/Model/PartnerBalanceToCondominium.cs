using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class PartnerBalanceToCondominium
    {
        [JsonPropertyName("partner")]
        public Partner Partner { get; set; }

        [JsonPropertyName("balance")]
        public Balance Balance { get; set; }
    }
}