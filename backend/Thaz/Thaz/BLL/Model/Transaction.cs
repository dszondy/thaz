using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DateTimeConverter = Thaz.API.Serialization.DateTimeConverter;

namespace Thaz.BLL.Model
{
    public class Transaction
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("amount")]
        public double Amount { get; set;}
        
        [JsonPropertyName("account_number")]
        public string AccountNumber {get; set; }
        
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date {get; set; }
        
        
        [JsonPropertyName("transaction_identifier")]
        public string TransactionIdentifier { get; set; }
        
        
        [JsonPropertyName("is_received")]
        public Boolean IsReceived { get; set; }
        
        [JsonPropertyName("partner")]
        public Partner Partner {get; set; }
        
        [JsonPropertyName("condominium")]
        public Condominium Condominium {get; set; }

    }
}