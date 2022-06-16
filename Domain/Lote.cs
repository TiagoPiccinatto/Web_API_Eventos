using System;
using System.Text.Json.Serialization;
using Domain.Modesl;

namespace Domain
{
    public class Lote
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        public string name { get; set; }

        public decimal preco { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Quantidade { get; set; }

        public int EventoId { get; set; }

        public EventoModel Evento { get; set; }

    }




}