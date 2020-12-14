using System.Reflection.Emit;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Thaz.BLL.Model
{
    public class Tag
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("rate")]
        public double Rate { get; set; }
    }
}