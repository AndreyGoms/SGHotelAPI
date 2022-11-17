using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SGHotelAPI.Model
{
    public class Conta
    {
        [Key]
        [JsonIgnore]
        public int? idConta { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Lancamento { get; set; }
        public DateTime Vencimento { get; set; }
        public string Tipo { get; set; }
    }
}
