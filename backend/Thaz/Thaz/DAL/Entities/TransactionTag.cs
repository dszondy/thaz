using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Thaz.BLL.Model;

namespace Thaz.DAL.Entities
{
    [Table("transaction_tags")]
    public class TransactionTag
    {        
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("label")]
        public string Label { get; set; }
        [Column("ratio")]
        public double Ratio { get; set; }
        public Transaction Transaction { get; set; }
        public Tag ToModel()
        {
            return new Tag()
            {
                Label = Label,
                Rate = Ratio
            };
        }
    }
}