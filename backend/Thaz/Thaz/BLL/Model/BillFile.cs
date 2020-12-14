using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thaz.BLL.Model
{
    [Table("billfile")]
    public class BillFile
    {
        [Column("bill")]
        public int? BillId { get; set;}
        
        [Column("id")][Key]
        public int? Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("type")]
        public string FileType { get; set; }
        [Column("extension")]
        public string Extension { get; set; }
        
        [Column("created")]
        public DateTime? CreatedOn { get; set; }
        [Column("data")]
        public byte[] Data { get; set; }
    }
}