using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGHotelAPI.Model
{
    public class Andar
    {
        [Key]
        [JsonIgnore]
        public int? idAndar { get; set; }
        public int Numero { get; set; }                   
    }
}
