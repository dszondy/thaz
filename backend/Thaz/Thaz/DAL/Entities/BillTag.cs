using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Thaz.BLL.Model;

namespace Thaz.DAL.Entities
{
    [Table("bill_tags")]
    public class BillTag
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("label")]
        public string Label { get; set; }
        [Column("ratio")]
        public double Ratio { get; set; }
        public Bill Bill { get; set; }

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