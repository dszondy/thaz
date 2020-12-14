using System.Text.Json.Serialization;

namespace Thaz.API.DTOs
{
    public class LoginResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}