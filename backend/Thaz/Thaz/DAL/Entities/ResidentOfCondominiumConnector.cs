using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thaz.DAL.Entities
{
    [Table("resident_condominium")]
    public class ResidentOfCondominiumConnector
    {
        public Condominium Condominium { get; set; }
        public Partner Partner { get; set; }
        [Column("partner_id")]
        public int PartnerId { get; set; }
        [Column("condominium_id")]
        public int CondominiumId { get; set; }
    }
}