using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Thaz.BLL.Model;

namespace Thaz.DAL.Entities
{
    [Table("partners")]
    public class Partner  : IOwnable
    {
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("phone")]
        public string Phone { get; set; }
        
        [Column("address")]
        public Address Address { get; set; }
        
        [Column("id")]
        public int? Id { get; set; }

        [Column("isresident")]
        public bool IsResident { get; set; }
        
        
        [Column("issupplier")]
        public bool IsSupplier { get; set; }
        
        public User Owner { get; set; }
        
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        
        public ICollection<Condominium> ResidentOf { get; set; }
        public ICollection<ResidentOfCondominiumConnector> ResidentConnectors { get; set; }

        public BLL.Model.Partner ToModel()
        {
            return new BLL.Model.Partner()
            {
                Address = Address?.toModel(),
                Name = Name,
                Phone = Phone,
                IsResident = IsResident,
                IsSupplier = IsSupplier,
                Id = Id
            };
        }

        public PartnerDetails ToModelDetails()
        {
            return new BLL.Model.PartnerDetails()
            {
                Address = Address?.toModel(),
                Name = Name,
                Phone = Phone,
                IsResident = IsResident,
                IsSupplier = IsSupplier,
                Id = Id,
                Condominiums = ResidentOf.Select(x => x.ToModel())
            };        
        }
    }
}