using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Thaz.API.Serialization;
using Thaz.BLL.Model;

namespace Thaz.DAL.Entities
{
    [Table("bills")]
    public class Bill : IOwnable
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("serial")]
        public string Serial{ get; set; }

        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("issued")]
        public DateTime? Created { get; set; }

        [Column("isissued")]
        public Boolean IssuedByCondominium { get; set; }

        [Column("done")]
        public Boolean Done { get; set; }
        
        [Column("partner_resident")]
        public Boolean PartnerResident { get; set; }
        
        [Column("deadline")]
        [System.Text.Json.Serialization.JsonConverter(typeof(DateTimeConverter))]
        public DateTime? PaymentDeadline { get; set; }

        public Partner Partner { get; set; }
        
        public Condominium Condominium {get; set; }

        public ICollection<BillItem> Items { get; set; }
        public User Owner { get; set; }
        [NotMapped]
        public double TotalPrice { get => Items.Sum(x => x.Price); }

        public ICollection<BillTag> Tags { get; set; }

        public BLL.Model.Bill ToModel()
        {
            return new BLL.Model.Bill()
            {
                Id = Id,
                Condominium = Condominium?.ToModel(),
                Created = Created,
                Description = Description,
                Done = Done,
                IssuedByCondominium = IssuedByCondominium,
                Partner = Partner?.ToModel(),
                PaymentDeadline = PaymentDeadline,
                Serial = Serial,
                TotalPrice = TotalPrice,
                PartnerResident = PartnerResident
            };
        }
        public BillDetails ToModelWithItems()
        {
            return new BillDetails()
            {
                Id = Id,
                Condominium = Condominium?.ToModel(),
                Created = Created,
                Description = Description,
                Done = Done,
                IssuedByCondominium = IssuedByCondominium,
                Partner = Partner?.ToModel(),
                PaymentDeadline = PaymentDeadline,
                Serial = Serial,
                TotalPrice = TotalPrice,
                Items = Items.Select(x => x.ToModel()).ToList(),
                PartnerResident = PartnerResident,
                Tags = Tags.Select(x => x.ToModel()).ToList()
            };
        }
    }
}