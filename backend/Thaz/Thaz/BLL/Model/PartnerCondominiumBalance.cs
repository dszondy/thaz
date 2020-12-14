using System.Text.Json.Serialization;

namespace Thaz.BLL.Model
{
    public class PartnerCondominiumBalance : PartnerBalanceToCondominium
    {
        [JsonPropertyName("condominium")]
        public Condominium Condominium { get; set; }
    }
}