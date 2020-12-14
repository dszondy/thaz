using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Thaz.API.DTOs
{
    public class PagedResponse<T>
    {
        [JsonPropertyName("values")]
        public IEnumerable<T> Values { get; set; }
        [JsonPropertyName("more_pages")]
        public bool MorePages { get; set; }
    }
}