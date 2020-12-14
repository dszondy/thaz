using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using Thaz.BLL.Model;
using DateTimeConverter = Thaz.API.Serialization.DateTimeConverter;

namespace Thaz.DAL.Entities
{
    [Table("transactions")]
    public class Transaction  : IOwnable
    {
        [Column("id")]
        public int? Id { get; set; }
        
        [Column("amount")]
        public double Amount { get; set;}
        
        [JsonPropertyName("account_number")]
        [Column("account_number")]
        public string AccountNumber {get; set; }
        
        [Column("date")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Date {get; set; }
        
        
        public Partner Partner {get; set; }

        
        public Condominium Condominium {get; set; }
        
        [Column("transaction_identifier")]
        public string TransactionIdentifier { get; set; }
        
        
        [Column("is_received")]
        public Boolean IsReceived { get; set; }
        public User Owner { get; set; }
        public ICollection<TransactionTag> Tags { get; set; }

        public TransactionDetails ToModelDetails()
        {
            return new BLL.Model.TransactionDetails()
            {
                Id = Id,
                Amount = Amount,
                AccountNumber = AccountNumber,
                Date = Date,
                IsReceived = IsReceived,
                Partner = Partner?.ToModel(),
                TransactionIdentifier = TransactionIdentifier,
                Condominium = Condominium?.ToModel(),
                Tags = Tags.Select(x => x.ToModel()).ToList()
            };
        }

        public BLL.Model.Transaction ToModel()
        {
            return new BLL.Model.Transaction()
            {
                Id = Id,
                Amount = Amount,
                AccountNumber = AccountNumber,
                Date = Date,
                IsReceived = IsReceived,
                Partner = Partner?.ToModel(),
                TransactionIdentifier = TransactionIdentifier
            };
        }
    }
}