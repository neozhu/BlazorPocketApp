using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pocketbase_csharp_sdk.Models
{
    public class UserModel : BaseAuthModel
    {
        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }
        
    }
}
