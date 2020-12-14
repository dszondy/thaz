﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Thaz.DAL.Entities
{
    [Table("billitems")]
    public class BillItem
    {
        [Column("id")]
        public int? Id { get; set; }

        [Column("description")]
        public string Description { get; set; }
        
        [Column("price")]
        public double Price { get; set; }
        
        public Bill Bill { get; set;}

        public BLL.Model.BillItem ToModel()
        {
            return new BLL.Model.BillItem()
            {
                Description = Description,
                Price = Price
            };
        }
    }
}