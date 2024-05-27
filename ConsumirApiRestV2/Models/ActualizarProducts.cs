using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumirApiRestV2.Models
{
    public class ActualizarProducts
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
