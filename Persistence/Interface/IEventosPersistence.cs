using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Modesl;

namespace Repositorio.Interface
{
    public interface IEventosPersistence
    {
        Task<EventoModel[]> GetAllEventosAsync(bool includePalestrantes = false);

        Task<EventoModel> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);

        Task<EventoModel[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false);

    }
}
