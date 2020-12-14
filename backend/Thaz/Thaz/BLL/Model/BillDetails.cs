using System.Collections.Generic;
using System.Text.Json.Serialization;
using Thaz.DAL.Entities;
using BillItem = Thaz.BLL.Model.BillItem;

namespace Thaz.BLL.Model
{
    public class BillDetails : BLL.Model.Bill
    {
        [JsonPropertyName("items")]
        public List<BillItem> Items { get; set; }
        
        [JsonPropertyName("tags")]
        public List<Tag> Tags { get; set; }

    }
}