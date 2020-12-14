using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Thaz.API.Serialization;

namespace Thaz.BLL.Model
{
    [Table("bills")]
    public class Bill
    {
        [JsonPropertyName("id")]
        [Key]
        public int? Id { get; set; }

        [JsonPropertyName("serial")]
        public string Serial{ get; set; }

        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("created")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Created { get; set; }

        [JsonPropertyName("partner_resident")]
        public Boolean PartnerResident { get; set; }
        
        [JsonPropertyName("total_price")]
        public double? TotalPrice
        {
            get;
            set;
        }
        
        [JsonPropertyName("issued_by_condominium")]
        public Boolean IssuedByCondominium { get; set; }

        [JsonPropertyName("done")]
        public Boolean Done { get; set; }
        
        [JsonPropertyName("deadline")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeConverter))]
        public DateTime? PaymentDeadline { get; set; }

        [JsonPropertyName("partner")]
        public Partner Partner { get; set; }
        
        [JsonPropertyName("condominium")]
        public Condominium Condominium {get; set; }
    }
}