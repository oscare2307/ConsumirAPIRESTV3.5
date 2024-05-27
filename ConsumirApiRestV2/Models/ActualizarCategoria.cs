using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumirApiRestV2.Models
{
    public class ActualizarCategoria
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
