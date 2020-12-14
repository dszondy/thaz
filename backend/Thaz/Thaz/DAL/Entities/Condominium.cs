using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Thaz.DAL.Entities
{
    [Table("condominiums")]
    public class Condominium  : IOwnable
    {
        [Column("name")]
        public string Name { get; set; }

        public Address Address { get; set; }
        
        [Column("id")]
        public int? Id { get; set; }
        public User Owner { get; set; }
        public List<Bill> Bills { get; set; }
        public List<Transaction> Transactions { get; set; }
        public ICollection<Partner> Residents { get; set; }
        public List<ResidentOfCondominiumConnector> ResidentConnectors { get; set; }

        public BLL.Model.Condominium ToModel()
        {
            return new BLL.Model.Condominium()
            {
                Id = Id,
                Address = Address?.toModel(),
                Name = Name
            };
        }
    }
}