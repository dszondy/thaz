using System.ComponentModel.DataAnnotations.Schema;

namespace Thaz.DAL.Repositories.Accounting
{
    [NotMapped]
    public class CondominiumPartner
    {
        [Column("cp_condominium_id")]
        public int CondominiumId { get; set; }
        [Column("cp_partner_id")]
        public int PartnerId { get; set; }

    }
}