
using System;
using System.Collections.Generic;

namespace Domain.Modesl
{
    public class EventoModel
    {
        
        public int Id { get; set; }
     
        public string Nome { get; set; }

        public string Local { get; set; }

        public DateTime? DataEvento { get; set; }

        public string Tema { get; set; }

        public int QtPessoas { get; set; }

        public string Lote { get; set; }

        public string  ImagemUrl  { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public IEnumerable<Lote> Lotes { get; set; }

        public IEnumerable<RedeSocial> RedeSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
    }

}
