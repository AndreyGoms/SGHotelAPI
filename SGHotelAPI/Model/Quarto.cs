using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SGHotelAPI.Model
{
    public class Quarto
    {
        [Key]
        [JsonIgnore]
        public int? idQuarto { get; set; }
        public int Numero_Quarto { get; set; }
        public int Capacidade { get; set; }
        public double Val_Diaria { get; set; }
        public bool isLimpo { get; set; }
        public int idAndar { get; set; }        
    }
}
