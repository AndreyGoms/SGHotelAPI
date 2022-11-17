using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SGHotelAPI.Model
{
    public class Cliente
    {
        [Key]
        [JsonIgnore]
        public int? IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public bool Status { get; set; }
    }
}
