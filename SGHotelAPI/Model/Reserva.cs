using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SGHotelAPI.Model
{
    public class Reserva
    {
        [Key]
        [JsonIgnore]
        public int? idReserva { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int idQuarto { get; set; }
        public int idCliente { get; set; }

    }
}
