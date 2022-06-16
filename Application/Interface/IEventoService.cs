using Domain.Modesl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IEventoService
    {
        Task<EventoModel> AddEventos(EventoModel model);
        
        Task<EventoModel> UpdateEventos(int eventoid, EventoModel model);

        Task<bool> DeletarEvento(int eventoid);


        Task<EventoModel[]> GetAllEventosAsync(bool includePalestrantes = false);

        Task<EventoModel> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);

        Task<EventoModel[]> GetEventosByTemaAsync(string tema, bool includePalestrantes = false);
    }
}
