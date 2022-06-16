using System;
using Domain.Modesl;

namespace Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }

        public Palestrante Palestrante { get; set; }

        public int EventoId { get; set; }

        public EventoModel Evento { get; set; }

    }
}